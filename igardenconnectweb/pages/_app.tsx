import '@/styles/globals.css'
import '@/styles/login.css'
import '@/styles/gardens.css'
import '@/styles/addGarden.css'
import '@/styles/index.css'
import 'bootstrap/dist/css/bootstrap.css'
import type { AppProps } from 'next/app'

export default function App({ Component, pageProps }: AppProps) {
  return <Component {...pageProps} />
}
