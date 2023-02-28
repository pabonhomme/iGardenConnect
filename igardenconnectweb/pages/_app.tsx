import '@/styles/globals.css'
import '@/styles/login.css'
import '@/styles/gardens.css'
import '@/styles/garden.css'
import '@/styles/addGarden.css'
import '@/styles/loading.css'
import '@/styles/index.css'
import '@/styles/forbidden.css'
import 'bootstrap/dist/css/bootstrap.css'
import styles from "@/styles/Home.module.css";
import type { AppProps } from 'next/app'
import { useEffect, useState } from 'react'
import { getUserByToken } from "../utils/cookie"
import { UserVM } from '@/model/UserVM'
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";
import Loading from "../components/Loading";

export default function App({ Component, pageProps }: AppProps) {
  const [user, setUser] = useState(new UserVM());
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getUserByToken().then(user => {
      setUser(user);
      setLoading(false);
    })
      .catch(() => {
        setLoading(false);
      })
  }, [])  

  if (loading) {
    return (
      <>
        <CustomHeader />
        <main className={styles.main}>
          <Loading/>
        </main>
      </>
    )
  }

  return (
    <>
      <CustomHeader />
      <CustomNavbar user={user} />
      <Component {...pageProps} user={user} />
    </>
  );
}
