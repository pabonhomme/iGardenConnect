import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import CustomNavbar from "./components/CustomNavbar";
import CustomHeader from "./components/CustomHeader";
import {
  Container,
  Carousel,
  Row,
  Col,
  Navbar,
  Nav,
  Button,
} from "react-bootstrap";

const inter = Inter({ subsets: ["latin"] });

export default function Home() {
  return (
    <>
      <CustomHeader/>
      <main className={styles.main}>
        <header>
          <CustomNavbar/>
        </header>
        <hr/>

        <div
          className="container-fluid p-5"
          id="Presentation"
        >
          <h1 className="display-4 font-weight-bold text-center">
            Bienvenue sur iGardenConnect
          </h1>
          <p className="lead font-weight-bold text-center">
            Simple. Utile. Intelligent.
          </p>
        </div>

        <div className={styles.center}>
        <Image className={styles.jardin} src="/jardin.jpg" alt="jardin" width="700" height="700"/>
        </div>
      </main>
    </>
  );
}
