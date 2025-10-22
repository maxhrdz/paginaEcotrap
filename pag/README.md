# EcoTraps Landing Page

Landing page profesional para EcoTraps, empresa especializada en trampas de grasa industriales.

## 🚀 Características

- **Diseño Responsive**: Optimizado para móvil, tablet y desktop
- **Interactividad**: Menú hamburguesa, FAQ acordeón, formulario de contacto
- **SEO Optimizado**: Estructura semántica HTML5 y meta tags
- **Accesibilidad**: Navegación por teclado y contraste adecuado
- **Performance**: Build optimizado con Vite

## 🛠️ Tecnologías Utilizadas

- **React 18.3.1** - Framework de UI
- **TypeScript 5.5.3** - Tipado estático
- **Tailwind CSS 3.4.1** - Framework CSS utility-first
- **Lucide React 0.344.0** - Iconos modernos
- **Vite 5.4.2** - Build tool y dev server
- **Google Fonts - Montserrat** - Tipografía profesional

## 🎨 Paleta de Colores

- **Verde Petróleo**: `#00A78E` → `#009B82` (gradiente principal)
- **Azul Acero**: `#004E8A` (secciones secundarias)
- **Azul Oscuro**: `#00345D` (footer y textos)
- **Gris Metálico**: `#5F6C75` (textos secundarios)
- **Gris Claro**: `#F6F8F9` (fondos alternativos)
- **WhatsApp**: `#25D366` (botón flotante)

## 📱 Secciones de la Landing Page

1. **Header**: Navegación fija con menú responsive
2. **Hero**: Sección principal con call-to-action
3. **Beneficios**: ¿Por qué elegir EcoTraps?
4. **Productos**: Catálogo de trampas de grasa
5. **Cómo Funciona**: Proceso en 3 pasos
6. **Testimonios**: Clientes que confían en EcoTraps
7. **FAQ**: Preguntas frecuentes con acordeón
8. **CTA**: Llamada a la acción principal
9. **Contacto**: Formulario e información de contacto
10. **Footer**: Enlaces y redes sociales

## 🚀 Instalación y Uso

### Prerrequisitos
- Node.js 18+ 
- npm o yarn

### Instalación
```bash
# Clonar el repositorio
git clone [url-del-repositorio]
cd ecotraps-landing

# Instalar dependencias
npm install

# Iniciar servidor de desarrollo
npm run dev
```

### Scripts Disponibles

```bash
# Desarrollo
npm run dev          # Inicia servidor de desarrollo en http://localhost:5173

# Producción
npm run build        # Genera build optimizado en carpeta dist/
npm run preview      # Preview del build de producción

# Linting
npm run lint         # Ejecuta ESLint para verificar código
```

## 📁 Estructura del Proyecto

```
ecotraps-landing/
├── src/
│   ├── App.tsx          # Componente principal con toda la landing
│   ├── main.tsx         # Entry point de la aplicación
│   ├── index.css        # Estilos globales + configuración Tailwind
│   └── vite-env.d.ts    # Tipos de Vite
├── public/              # Archivos estáticos
├── index.html           # HTML principal
├── package.json         # Dependencias y scripts
├── tsconfig.json        # Configuración TypeScript
├── tailwind.config.js   # Configuración Tailwind CSS
├── vite.config.ts       # Configuración Vite
└── eslint.config.js     # Configuración ESLint
```

## 🎯 Funcionalidades Implementadas

### ✅ Interactividad
- Menú hamburguesa responsive
- Navegación suave entre secciones
- FAQ con acordeón interactivo
- Formulario de contacto con validación
- Estados hover en botones y tarjetas
- Botón flotante de WhatsApp

### ✅ Responsive Design
- Breakpoints: móvil (< 768px), tablet (768px+), desktop (1024px+)
- Grid adaptativo para tarjetas
- Imágenes y espaciados adaptativos
- Menú colapsable en móvil

### ✅ SEO y Accesibilidad
- Estructura semántica HTML5
- Meta tags optimizados
- Etiquetas de formulario accesibles
- Contraste de colores adecuado
- Navegación por teclado funcional

## 🚀 Deployment

La aplicación está lista para ser desplegada en plataformas estáticas:

### GitHub Pages
```bash
npm run build
# Subir contenido de dist/ a GitHub Pages
```

### Netlify
```bash
npm run build
# Arrastrar carpeta dist/ a Netlify
```

### Vercel
```bash
npm run build
# Conectar repositorio con Vercel
```

## 🔧 Personalización

### Colores
Los colores se pueden modificar en `tailwind.config.js`:

```javascript
colors: {
  'petroleum': {
    500: '#00A78E',  // Color principal
    600: '#009B82',  // Color hover
  },
  'steel-blue': '#004E8A',
  // ... más colores
}
```

### Contenido
Todo el contenido está en `src/App.tsx` y se puede modificar directamente:
- Textos y títulos
- Información de contacto
- Productos y precios
- FAQ y testimonios

### Imágenes
Para agregar imágenes reales:
1. Colocar imágenes en carpeta `public/`
2. Actualizar las referencias en el código
3. Optimizar imágenes para web

## 📞 Soporte

Para soporte técnico o consultas sobre el proyecto:
- Email: contacto@ecotraps.cl
- Teléfono: +56 9 1234 5678
- WhatsApp: [Botón flotante en la página]

## 📄 Licencia

© 2025 EcoTraps. Todos los derechos reservados.

---

**Desarrollado con ❤️ para EcoTraps**


