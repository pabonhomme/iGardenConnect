import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
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
      <main className={styles.main}>
        <hr />

        <div className="container-fluid p-5" id="Presentation">
          <h1 className="display-4 font-weight-bold text-center">
            Bienvenue sur iGardenConnect
          </h1>
          <p className="lead font-weight-bold text-center">
            Simple. Utile. Intelligent.
          </p>
        </div>

        <div className="containerGarden">
          <Image
            className="garden"
            src="/jardin.jpg"
            alt="jardin"
            width="700"
            height="700"
          />
        </div>
      </main>
    </>
  );
}
