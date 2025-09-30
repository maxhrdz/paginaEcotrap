using System.Data;
using Blog.Models;
using Microsoft.Data.Sqlite;

namespace Blog.Data
{
    /// <summary>
    /// Implementation of <see cref="IArticleRepository"/> using SQLite as a persistence solution.
    /// </summary>
    public class ArticleRepository : IArticleRepository
    {
        private readonly string _connectionString;

        public ArticleRepository(DatabaseConfig _config)
        {
            _connectionString = _config.DefaultConnectionString
                ?? throw new ArgumentNullException("Connection string not found");
            EnsureCreated();
        }

        private SqliteConnection Open()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            // Asegura FKs en cada conexión
            using var pragma = conn.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();
            return conn;
        }

        private static Article ReadArticle(IDataRecord r)
        {
            // Cols: Id, Title, AuthorName, AuthorEmail, Content, PublishedDateUtc
            return new Article
            {
                Id = r.GetInt32(0),
                Title = r.GetString(1),
                AuthorName = r.GetString(2),
                AuthorEmail = r.GetString(3),
                Content = r.GetString(4),
                // Guardamos como ISO-8601 UTC ("o")
                PublishedDate = DateTimeOffset.Parse(r.GetString(5), null, System.Globalization.DateTimeStyles.AssumeUniversal)
            };
        }

        private static Comment ReadComment(IDataRecord r)
        {
            // Cols: ArticleId, Content, PublishedDateUtc
            return new Comment
            {
                ArticleId = r.GetInt32(0),
                Content = r.GetString(1),
                PublishedDate = DateTimeOffset.Parse(r.GetString(2), null, System.Globalization.DateTimeStyles.AssumeUniversal)
            };
        }

        /// <summary>
        /// Creates the necessary tables for this application if they don't exist already.
        /// Should be called once when starting the service.
        /// </summary>
        public void EnsureCreated()
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
CREATE TABLE IF NOT EXISTS Articles (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    Title           TEXT    NOT NULL CHECK(length(Title) <= 100),
    AuthorName      TEXT    NOT NULL,
    AuthorEmail     TEXT    NOT NULL,
    Content         TEXT    NOT NULL,
    PublishedDateUtc TEXT   NOT NULL
);

CREATE TABLE IF NOT EXISTS Comments (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    ArticleId       INTEGER NOT NULL,
    Content         TEXT    NOT NULL,
    PublishedDateUtc TEXT   NOT NULL,
    FOREIGN KEY (ArticleId) REFERENCES Articles(Id) ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS IX_Articles_PublishedDate ON Articles(PublishedDateUtc);
CREATE INDEX IF NOT EXISTS IX_Comments_ArticleId_Date ON Comments(ArticleId, PublishedDateUtc);
";
            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Article> GetAll()
        {
            var list = new List<Article>();
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
SELECT Id, Title, AuthorName, AuthorEmail, Content, PublishedDateUtc
FROM Articles
ORDER BY datetime(PublishedDateUtc) DESC;";
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                list.Add(ReadArticle(rd));
            return list;
        }

        public IEnumerable<Article> GetByDateRange(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var list = new List<Article>();
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
SELECT Id, Title, AuthorName, AuthorEmail, Content, PublishedDateUtc
FROM Articles
WHERE datetime(PublishedDateUtc) >= datetime(@startUtc)
  AND datetime(PublishedDateUtc) <= datetime(@endUtc)
ORDER BY datetime(PublishedDateUtc) DESC;";
            cmd.Parameters.AddWithValue("@startUtc", startDate.UtcDateTime.ToString("o"));
            cmd.Parameters.AddWithValue("@endUtc", endDate.UtcDateTime.ToString("o"));
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                list.Add(ReadArticle(rd));
            return list;
        }

        public Article? GetById(int id)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
SELECT Id, Title, AuthorName, AuthorEmail, Content, PublishedDateUtc
FROM Articles
WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            using var rd = cmd.ExecuteReader();
            return rd.Read() ? ReadArticle(rd) : null;
        }

        public Article Create(Article article)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
INSERT INTO Articles (Title, AuthorName, AuthorEmail, Content, PublishedDateUtc)
VALUES (@t, @an, @ae, @c, @pd);
SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("@t", article.Title);
            cmd.Parameters.AddWithValue("@an", article.AuthorName);
            cmd.Parameters.AddWithValue("@ae", article.AuthorEmail);
            cmd.Parameters.AddWithValue("@c", article.Content);
            cmd.Parameters.AddWithValue("@pd", article.PublishedDate.UtcDateTime.ToString("o"));

            var newId = (long)(cmd.ExecuteScalar() ?? 0);
            article.Id = (int)newId;
            return article;
        }

        public void AddComment(Comment comment)
        {
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
INSERT INTO Comments (ArticleId, Content, PublishedDateUtc)
VALUES (@aid, @c, @pd);";
            cmd.Parameters.AddWithValue("@aid", comment.ArticleId);
            cmd.Parameters.AddWithValue("@c", comment.Content);
            cmd.Parameters.AddWithValue("@pd", comment.PublishedDate.UtcDateTime.ToString("o"));
            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Comment> GetCommentsByArticleId(int articleId)
        {
            var list = new List<Comment>();
            using var conn = Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
SELECT ArticleId, Content, PublishedDateUtc
FROM Comments
WHERE ArticleId = @aid
ORDER BY datetime(PublishedDateUtc) DESC;";
            cmd.Parameters.AddWithValue("@aid", articleId);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                list.Add(ReadComment(rd));
            return list;
        }
    }
}
