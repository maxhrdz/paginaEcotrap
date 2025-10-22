import { useState } from 'react'
import { useForm, ValidationError } from '@formspree/react'
import { 
  Menu, 
  X, 
  Check, 
  Droplet, 
  Clock, 
  Shield, 
  ChevronDown, 
  Phone, 
  Mail, 
  Settings,
  Wrench,
  ExternalLink
} from 'lucide-react'

// compo
const EcoTrapLogo = ({ className = "" }: { className?: string }) => (
  <div className={`flex items-center ${className}`}>
    <img 
      src="/logo-ecotrap.png" 
      alt="EcoTrap Logo" 
      className="h-20 w-auto object-contain"
    />
  </div>
)

function App() {
  const [isMenuOpen, setIsMenuOpen] = useState(false)
  const [openFAQ, setOpenFAQ] = useState<number | null>(null)
  const [state, handleSubmit] = useForm("manpkkjl")

  const toggleMenu = () => setIsMenuOpen(!isMenuOpen)
  const toggleFAQ = (index: number) => {
    setOpenFAQ(openFAQ === index ? null : index)
  }

  const scrollToSection = (sectionId: string) => {
    const element = document.getElementById(sectionId)
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' })
    }
    setIsMenuOpen(false)
  }

  return (
    <div className="min-h-screen bg-white">
      {/* Header */}
      <header className="fixed top-0 w-full bg-white/95 backdrop-blur-md shadow-lg border-b border-gray-100 z-50">
        <div className="container mx-auto px-4 py-2">
          <div className="flex items-center justify-between">
            <EcoTrapLogo />
            
            {/* Desktop Navigation */}
            <nav className="hidden md:flex space-x-8">
              <button 
                onClick={() => scrollToSection('inicio')}
                className="text-gray-700 hover:text-primary-500 transition-colors"
              >
                Inicio
              </button>
              <button 
                onClick={() => scrollToSection('catalogo')}
                className="text-gray-700 hover:text-primary-500 transition-colors"
              >
                Catálogo
              </button>
              <button 
                onClick={() => scrollToSection('contacto')}
                className="text-gray-700 hover:text-primary-500 transition-colors"
              >
                Contacto
              </button>
            </nav>

            {/* Mobile Menu Button */}
            <button 
              onClick={toggleMenu}
              className="md:hidden p-2"
            >
              {isMenuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
            </button>
          </div>

          {/* Mobile Navigation */}
          {isMenuOpen && (
            <nav className="md:hidden mt-4 pb-4 border-t border-gray-200">
              <div className="flex flex-col space-y-2 pt-4">
                <button 
                  onClick={() => scrollToSection('inicio')}
                  className="text-left py-2 text-gray-700 hover:text-primary-500 transition-colors"
                >
                  Inicio
                </button>
                <button 
                  onClick={() => scrollToSection('catalogo')}
                  className="text-left py-2 text-gray-700 hover:text-primary-500 transition-colors"
                >
                  Catálogo
                </button>
                <button 
                  onClick={() => scrollToSection('contacto')}
                  className="text-left py-2 text-gray-700 hover:text-primary-500 transition-colors"
                >
                  Contacto
                </button>
              </div>
            </nav>
          )}
        </div>
      </header>

      {/* Hero Section */}
      <section id="inicio" className="pt-20 bg-gradient-to-br from-blue-50 via-primary-100 to-accent-100 min-h-screen flex items-center relative overflow-hidden">
        {/* Fondo decorativo con elementos industriales */}
        <div className="absolute inset-0 bg-gradient-to-r from-transparent via-primary-200/30 to-transparent"></div>
        
        {/* Patrón de fondo sutil */}
        <div className="absolute inset-0 opacity-15">
          <div className="absolute top-20 left-10 w-32 h-32 bg-primary-500 rounded-full blur-3xl"></div>
          <div className="absolute top-40 right-20 w-24 h-24 bg-accent-500 rounded-full blur-2xl"></div>
          <div className="absolute bottom-32 left-1/4 w-40 h-40 bg-primary-300 rounded-full blur-3xl"></div>
          <div className="absolute bottom-20 right-1/3 w-28 h-28 bg-accent-400 rounded-full blur-2xl"></div>
        </div>
        
        {/* Líneas decorativas */}
        <div className="absolute inset-0 opacity-20">
          <div className="absolute top-1/4 left-0 w-full h-px bg-gradient-to-r from-transparent via-primary-500 to-transparent"></div>
          <div className="absolute top-3/4 left-0 w-full h-px bg-gradient-to-r from-transparent via-accent-500 to-transparent"></div>
        </div>
        
        {/* Elementos geométricos industriales */}
        <div className="absolute inset-0 opacity-10">
          <div className="absolute top-16 right-16 w-16 h-16 border-2 border-primary-500 rotate-45"></div>
          <div className="absolute bottom-24 left-16 w-12 h-12 border-2 border-accent-500 rotate-12"></div>
          <div className="absolute top-1/2 right-8 w-8 h-8 bg-primary-400 rotate-45"></div>
        </div>
        
        {/* Textura de fondo */}
        <div className="absolute inset-0 opacity-8 bg-gradient-to-br from-primary-200/30 via-transparent to-accent-200/30"></div>
        <div className="container mx-auto px-4 py-20 pb-32 relative z-10">
          <div className="grid md:grid-cols-2 gap-12 items-center">
            {/* Texto a la izquierda */}
            <div className="text-primary-800">
              <h1 className="text-4xl md:text-6xl font-bold mb-12 leading-loose bg-gradient-to-r from-primary-500 via-primary-600 to-accent-500 bg-clip-text text-transparent" style={{lineHeight: '1.3'}}>
                Trampas de grasa confiables para tu negocio
              </h1>
              <p className="text-lg md:text-xl mb-12 leading-relaxed text-primary-600">
                Soluciones confiables para el manejo de grasa y residuos
              </p>
              <button 
                onClick={() => scrollToSection('contacto')}
                className="bg-gradient-to-r from-primary-500 to-accent-500 text-white px-10 py-5 rounded-xl text-lg font-semibold hover:from-primary-600 hover:to-accent-600 transition-all duration-300 shadow-xl hover:shadow-2xl transform hover:-translate-y-1"
              >
                Cotizar ahora
              </button>
            </div>
            
            {/* Imagen a la derecha */}
            <div className="flex justify-center md:justify-end">
              <div className="relative">
                <img 
                  src="/trampa3.png" 
                  alt="Trampa de grasa industrial" 
                  className="w-full max-w-4xl h-auto object-contain"
                />
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Benefits Section */}
      <section className="section-professional bg-gradient-to-br from-gray-50 to-gray-100">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-4xl md:text-5xl font-bold text-primary-dark mb-6">
              ¿Por qué elegir EcoTraps?
            </h2>
            <p className="text-xl text-muted max-w-3xl mx-auto">
              Soluciones profesionales que marcan la diferencia en tu industria
            </p>
          </div>
          <div className="grid md:grid-cols-3 gap-8">
            <div className="card-professional text-center p-8 group">
              <div className="w-20 h-20 bg-primary-gradient rounded-2xl flex items-center justify-center mx-auto mb-6 group-hover:scale-110 transition-transform duration-300">
                <Shield className="w-10 h-10 text-white" />
              </div>
              <h3 className="text-2xl font-semibold mb-4 text-primary-dark">Cumplimiento sanitario</h3>
              <p className="text-muted leading-relaxed">
                Cumplimos con todas las normativas sanitarias vigentes, garantizando la seguridad y calidad de tu establecimiento.
              </p>
            </div>
            <div className="card-professional text-center p-8 group">
              <div className="w-20 h-20 bg-primary-gradient rounded-2xl flex items-center justify-center mx-auto mb-6 group-hover:scale-110 transition-transform duration-300">
                <Clock className="w-10 h-10 text-white" />
              </div>
              <h3 className="text-2xl font-semibold mb-4 text-primary-dark">Instalación rápida</h3>
              <p className="text-muted leading-relaxed">
                Nuestro equipo técnico especializado realiza instalaciones eficientes con mínima interrupción de tu operación.
              </p>
            </div>
            <div className="card-professional text-center p-8 group">
              <div className="w-20 h-20 bg-primary-gradient rounded-2xl flex items-center justify-center mx-auto mb-6 group-hover:scale-110 transition-transform duration-300">
                <Check className="w-10 h-10 text-white" />
              </div>
              <h3 className="text-2xl font-semibold mb-4 text-primary-dark">Mantenimiento fácil</h3>
              <p className="text-muted leading-relaxed">
                Diseño intuitivo que facilita el mantenimiento regular, reduciendo costos operativos a largo plazo.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* Catalog Section */}
      <section id="catalogo" className="section-professional bg-primary-gradient relative overflow-hidden">
        <div className="absolute inset-0 bg-gradient-to-br from-primary-600/90 to-secondary-600/90"></div>
        <div className="container mx-auto px-4 text-center relative z-10">
          <div className="mb-12">
            <div className="w-24 h-24 bg-white/20 rounded-3xl flex items-center justify-center mx-auto mb-8 backdrop-blur-sm">
              <Droplet className="w-12 h-12 text-white" />
            </div>
          </div>
          <h2 className="text-4xl md:text-5xl font-bold text-white mb-8 leading-tight">
            Catálogo de Productos
          </h2>
          <p className="text-xl text-white/90 mb-12 max-w-4xl mx-auto leading-relaxed">
            Descubre nuestra amplia gama de trampas de grasa industriales. Encuentra la solución perfecta para las necesidades específicas de tu negocio.
          </p>
          <a
            href="/catalogo-ecotraps.pdf"
            target="_blank"
            rel="noopener noreferrer"
            className="inline-flex items-center space-x-3 bg-white text-primary-600 px-10 py-5 rounded-xl text-lg font-semibold hover:bg-gray-50 transition-all duration-300 shadow-xl hover:shadow-2xl transform hover:-translate-y-1"
          >
            <span>Ver Catálogo de Productos</span>
            <ExternalLink className="w-5 h-5" />
          </a>
          <p className="text-white/80 mt-6 text-base">
            Explora especificaciones técnicas, capacidades y modelos disponibles
          </p>
        </div>
      </section>

      {/* How it Works Section */}
      <section className="section-professional bg-white">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-4xl md:text-5xl font-bold text-primary-dark mb-6">
              ¿Cómo funciona?
            </h2>
            <p className="text-xl text-muted max-w-3xl mx-auto">
              Un proceso simple y eficiente en tres pasos
            </p>
          </div>
          <div className="grid md:grid-cols-3 gap-12">
            <div className="text-center group">
              <div className="w-24 h-24 bg-primary-gradient rounded-3xl flex items-center justify-center mx-auto mb-8 group-hover:scale-110 transition-transform duration-300 shadow-lg">
                <span className="text-white text-2xl font-bold">1</span>
              </div>
              <h3 className="text-2xl font-semibold mb-6 text-primary-dark">Separación</h3>
              <p className="text-muted leading-relaxed text-lg">
                El agua residual ingresa a la trampa donde las grasas se separan naturalmente por diferencia de densidad.
              </p>
            </div>
            <div className="text-center group">
              <div className="w-24 h-24 bg-primary-gradient rounded-3xl flex items-center justify-center mx-auto mb-8 group-hover:scale-110 transition-transform duration-300 shadow-lg">
                <span className="text-white text-2xl font-bold">2</span>
              </div>
              <h3 className="text-2xl font-semibold mb-6 text-primary-dark">Retención</h3>
              <p className="text-muted leading-relaxed text-lg">
                Las grasas quedan retenidas en la parte superior mientras el agua limpia continúa su flujo hacia el drenaje.
              </p>
            </div>
            <div className="text-center group">
              <div className="w-24 h-24 bg-primary-gradient rounded-3xl flex items-center justify-center mx-auto mb-8 group-hover:scale-110 transition-transform duration-300 shadow-lg">
                <span className="text-white text-2xl font-bold">3</span>
              </div>
              <h3 className="text-2xl font-semibold mb-6 text-primary-dark">Mantenimiento</h3>
              <p className="text-muted leading-relaxed text-lg">
                Limpieza periódica de las grasas acumuladas para mantener la eficiencia del sistema.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* Services Section */}
      <section className="section-professional bg-gradient-to-br from-gray-50 to-gray-100">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-4xl md:text-5xl font-bold text-primary-dark mb-6">
              Nuestros Servicios
            </h2>
            <p className="text-xl text-muted max-w-4xl mx-auto">
              Ofrecemos servicios profesionales integrales para garantizar el óptimo funcionamiento de tu sistema
            </p>
          </div>
          <div className="grid md:grid-cols-2 gap-12 max-w-6xl mx-auto">
            <div className="card-professional p-10 group">
              <div className="w-20 h-20 bg-green-100 rounded-2xl flex items-center justify-center mx-auto mb-8 group-hover:scale-110 transition-transform duration-300">
                <Settings className="w-10 h-10 text-green-600" />
              </div>
              <h3 className="text-3xl font-bold text-primary-dark mb-6 text-center">
                Instalación
              </h3>
              <p className="text-muted text-center leading-relaxed text-lg">
              Instalamos tu trampa de grasa con análisis previo del espacio, cumpliendo normativas vigentes.
              Garantizamos una instalación profesional, segura y sin interrupciones.
              </p>
            </div>
            <div className="card-professional p-10 group">
              <div className="w-20 h-20 bg-blue-100 rounded-2xl flex items-center justify-center mx-auto mb-8 group-hover:scale-110 transition-transform duration-300">
                <Wrench className="w-10 h-10 text-blue-600" />
              </div>
              <h3 className="text-3xl font-bold text-primary-dark mb-6 text-center">
                Mantenimiento
              </h3>
              <p className="text-muted text-center leading-relaxed text-lg">
              Ofrecemos mantenimiento preventivo y correctivo para maximizar la vida útil de tu equipo.
              Incluye limpieza, inspección técnica y planes adaptados a tu negocio.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* FAQ Section */}
      <section className="section-professional bg-white">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-4xl md:text-5xl font-bold text-primary-dark mb-6">
              Preguntas Frecuentes
            </h2>
            <p className="text-xl text-muted max-w-3xl mx-auto">
              Resolvemos las dudas más comunes sobre nuestros productos y servicios
            </p>
          </div>
          <div className="max-w-4xl mx-auto space-y-6">
            <div className="card-professional">
              <button 
                onClick={() => toggleFAQ(0)}
                className="w-full p-8 text-left flex justify-between items-center hover:bg-gray-50/50 transition-all duration-300 rounded-2xl"
              >
                <span className="font-semibold text-lg text-primary-dark">¿Cada cuánto debo limpiar mi trampa de grasa?</span>
                <ChevronDown className={`w-6 h-6 transition-transform duration-300 text-primary-500 ${openFAQ === 0 ? 'rotate-180' : ''}`} />
              </button>
              {openFAQ === 0 && (
                <div className="px-8 pb-8">
                  <p className="text-muted leading-relaxed text-lg">
                    La frecuencia de limpieza depende del volumen de uso. Para restaurantes pequeños recomendamos cada 3 meses, 
                    mientras que para establecimientos de alto volumen puede ser mensual. Nuestro equipo puede ayudarte a determinar 
                    el cronograma ideal según tu operación.
                  </p>
                </div>
              )}
            </div>
            <div className="card-professional">
              <button 
                onClick={() => toggleFAQ(1)}
                className="w-full p-8 text-left flex justify-between items-center hover:bg-gray-50/50 transition-all duration-300 rounded-2xl"
              >
                <span className="font-semibold text-lg text-primary-dark">¿Qué capacidad necesito para mi establecimiento?</span>
                <ChevronDown className={`w-6 h-6 transition-transform duration-300 text-primary-500 ${openFAQ === 1 ? 'rotate-180' : ''}`} />
              </button>
              {openFAQ === 1 && (
                <div className="px-8 pb-8">
                  <p className="text-muted leading-relaxed text-lg">
                    La capacidad depende del número de platos servidos diariamente y el tipo de cocina. 
                    Para cafeterías pequeñas (hasta 50 platos/día) recomendamos 50 litros, 
                    para restaurantes medianos (50-200 platos/día) 100 litros, 
                    y para cocinas industriales (más de 200 platos/día) 200+ litros.
                  </p>
                </div>
              )}
            </div>
            <div className="card-professional">
              <button 
                onClick={() => toggleFAQ(2)}
                className="w-full p-8 text-left flex justify-between items-center hover:bg-gray-50/50 transition-all duration-300 rounded-2xl"
              >
                <span className="font-semibold text-lg text-primary-dark">¿Ofrecen servicio de instalación?</span>
                <ChevronDown className={`w-6 h-6 transition-transform duration-300 text-primary-500 ${openFAQ === 2 ? 'rotate-180' : ''}`} />
              </button>
              {openFAQ === 2 && (
                <div className="px-8 pb-8">
                  <p className="text-muted leading-relaxed text-lg">
                    Sí, contamos con un equipo técnico especializado que realiza la instalación completa, 
                    incluyendo conexiones, pruebas de funcionamiento y capacitación del personal. 
                    También ofrecemos servicio de mantenimiento preventivo y correctivo.
                  </p>
                </div>
              )}
            </div>
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section className="section-professional bg-secondary-gradient relative overflow-hidden">
        <div className="absolute inset-0 bg-gradient-to-br from-secondary-600/90 to-primary-600/90"></div>
        <div className="container mx-auto px-4 text-center relative z-10">
          <h2 className="text-4xl md:text-5xl font-bold text-white mb-8 leading-tight">
            ¿Listo para mejorar tu sistema de gestión de grasas?
          </h2>
          <p className="text-xl text-white/90 mb-12 max-w-4xl mx-auto leading-relaxed">
            Obtén una cotización personalizada sin compromiso
          </p>
          <button 
            onClick={() => scrollToSection('contacto')}
            className="bg-white text-secondary-600 px-10 py-5 rounded-xl text-lg font-semibold hover:bg-gray-50 transition-all duration-300 shadow-xl hover:shadow-2xl transform hover:-translate-y-1"
          >
            Solicitar cotización
          </button>
        </div>
      </section>

      {/* Contact Section */}
      <section id="contacto" className="section-professional bg-gradient-to-br from-gray-50 to-gray-100">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-4xl md:text-5xl font-bold text-primary-dark mb-6">
              Contáctanos
            </h2>
            <p className="text-xl text-muted max-w-3xl mx-auto">
              Estamos aquí para ayudarte con tu proyecto
            </p>
          </div>
          <div className="grid md:grid-cols-2 gap-16 max-w-6xl mx-auto">
            {/* Contact Form */}
            <div className="card-professional p-8">
              {state.succeeded ? (
                <div className="text-center py-8">
                  <div className="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-6">
                    <Check className="w-8 h-8 text-green-600" />
                  </div>
                  <h3 className="text-2xl font-bold text-green-600 mb-4">¡Mensaje enviado!</h3>
                  <p className="text-muted text-lg">
                    Gracias por contactarnos. Te responderemos pronto.
                  </p>
                </div>
              ) : (
                <form onSubmit={handleSubmit} className="space-y-8">
                  <div>
                    <label htmlFor="nombre" className="block text-sm font-semibold text-primary-dark mb-3">
                      Nombre *
                    </label>
                    <input
                      type="text"
                      id="nombre"
                      name="nombre"
                      required
                      className="w-full px-5 py-4 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-transparent transition-all duration-300 text-lg"
                      placeholder="Tu nombre completo"
                    />
                  </div>
                  <div>
                    <label htmlFor="empresa" className="block text-sm font-semibold text-primary-dark mb-3">
                      Empresa
                    </label>
                    <input
                      type="text"
                      id="empresa"
                      name="empresa"
                      className="w-full px-5 py-4 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-transparent transition-all duration-300 text-lg"
                      placeholder="Nombre de tu empresa"
                    />
                  </div>
                  <div>
                    <label htmlFor="email" className="block text-sm font-semibold text-primary-dark mb-3">
                      Email *
                    </label>
                    <input
                      type="email"
                      id="email"
                      name="email"
                      required
                      className="w-full px-5 py-4 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-transparent transition-all duration-300 text-lg"
                      placeholder="tu@email.com"
                    />
                    <ValidationError 
                      prefix="Email" 
                      field="email"
                      errors={state.errors}
                      className="text-red-500 text-sm mt-2"
                    />
                  </div>
                  <div>
                    <label htmlFor="telefono" className="block text-sm font-semibold text-primary-dark mb-3">
                      Teléfono
                    </label>
                    <input
                      type="tel"
                      id="telefono"
                      name="telefono"
                      className="w-full px-5 py-4 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-transparent transition-all duration-300 text-lg"
                      placeholder="+56 9 1234 5678"
                    />
                  </div>
                  <div>
                    <label htmlFor="mensaje" className="block text-sm font-semibold text-primary-dark mb-3">
                      Mensaje *
                    </label>
                    <textarea
                      id="mensaje"
                      name="mensaje"
                      required
                      rows={5}
                      className="w-full px-5 py-4 border border-gray-200 rounded-xl focus:ring-2 focus:ring-primary-500 focus:border-transparent transition-all duration-300 text-lg resize-none"
                      placeholder="Cuéntanos sobre tu proyecto..."
                    />
                    <ValidationError 
                      prefix="Mensaje" 
                      field="mensaje"
                      errors={state.errors}
                      className="text-red-500 text-sm mt-2"
                    />
                  </div>
                  <button
                    type="submit"
                    disabled={state.submitting}
                    className="w-full bg-primary-gradient text-white py-5 rounded-xl font-semibold hover:opacity-90 transition-all duration-300 text-lg shadow-lg hover:shadow-xl transform hover:-translate-y-1 disabled:opacity-50 disabled:cursor-not-allowed disabled:transform-none"
                  >
                    {state.submitting ? 'Enviando...' : 'Enviar mensaje'}
                  </button>
                </form>
              )}
            </div>

            {/* Contact Information */}
            <div className="space-y-12">
              <div className="card-professional p-8">
                <div className="flex items-start space-x-6">
                  <div className="w-16 h-16 bg-primary-gradient rounded-2xl flex items-center justify-center flex-shrink-0">
                    <Phone className="w-8 h-8 text-white" />
                  </div>
                  <div>
                    <h3 className="text-2xl font-bold text-primary-dark mb-3">Teléfono</h3>
                    <p className="text-muted text-lg">+1 (619) 761-3607</p>
                    <p className="text-muted text-sm mt-2">Lunes a Viernes: 8:00 - 18:00</p>
                  </div>
                </div>
              </div>
              <div className="card-professional p-8">
                <div className="flex items-start space-x-6">
                  <div className="w-16 h-16 bg-primary-gradient rounded-2xl flex items-center justify-center flex-shrink-0">
                    <Mail className="w-8 h-8 text-white" />
                  </div>
                  <div>
                    <h3 className="text-2xl font-bold text-primary-dark mb-3">Email</h3>
                    <p className="text-muted text-lg">sandiegobutchersupply@yahoo.com</p>
                    <p className="text-muted text-sm mt-2">Respuesta en menos de 24 horas</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer className="bg-gradient-to-br from-secondary-800 to-secondary-900 text-white py-16">
        <div className="container mx-auto px-4">
          <div className="grid md:grid-cols-3 gap-12 mb-12">
            <div>
              <h3 className="text-2xl font-bold mb-6">EcoTraps</h3>
              <p className="text-gray-300 leading-relaxed text-lg">
                Soluciones profesionales para la gestión eficiente de grasas en tu establecimiento.
              </p>
            </div>
            <div>
              <h3 className="text-xl font-semibold mb-6">Enlaces rápidos</h3>
              <div className="space-y-4">
                <button 
                  onClick={() => scrollToSection('inicio')}
                  className="block text-gray-300 hover:text-white transition-colors text-lg"
                >
                  Inicio
                </button>
                <button 
                  onClick={() => scrollToSection('catalogo')}
                  className="block text-gray-300 hover:text-white transition-colors text-lg"
                >
                  Catálogo
                </button>
                <button 
                  onClick={() => scrollToSection('contacto')}
                  className="block text-gray-300 hover:text-white transition-colors text-lg"
                >
                  Contacto
                </button>
              </div>
            </div>
            <div>
              <h3 className="text-xl font-semibold mb-6">Síguenos</h3>
              <div className="flex space-x-4">
                <a 
                  href="https://www.facebook.com/profile.php?id=61582477623307"
                  target="_blank"
                  rel="noopener noreferrer"
                  className="w-14 h-14 bg-blue-600 rounded-2xl flex items-center justify-center hover:bg-blue-700 transition-all duration-300 shadow-lg hover:shadow-xl transform hover:-translate-y-1"
                  title="Síguenos en Facebook"
                >
                  <span className="text-xl font-bold text-white">f</span>
                </a>
              </div>
            </div>
          </div>
          <div className="border-t border-gray-600 pt-8 text-center">
            <p className="text-gray-300 text-lg">© 2025 EcoTraps. Todos los derechos reservados.</p>
          </div>
        </div>
      </footer>

    </div>
  )
}

export default App