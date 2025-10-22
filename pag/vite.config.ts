import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
export default defineConfig({
  plugins: [react()],
  base: '/', // asegura rutas absolutas como /logo-ecotrap.png
})
