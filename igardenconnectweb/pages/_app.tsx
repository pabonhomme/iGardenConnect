import '@/styles/globals.css'
import '@/styles/login.css'
import '@/styles/gardens.css'
import '@/styles/addGarden.css'
import '@/styles/index.css'
import 'bootstrap/dist/css/bootstrap.css'
import type { AppProps } from 'next/app'
import { useEffect, useState } from 'react'
import { getUserByToken } from "../utils/cookie"
import { UserVM } from '@/model/UserVM'
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";

export default function App({ Component, pageProps }: AppProps) {
  const [user, setUser] = useState(new UserVM())

  useEffect(() => {
    async function fetchUser() {
      const user = await getUserByToken()
      setUser(user)
    }
    fetchUser()
  }, [])
  return (
    <>
      <CustomHeader />
      <CustomNavbar login={user.login}/>
      <Component {...pageProps} />
    </>
  );
}
