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

export default function AddGarden() {
  return (
    <>
      <CustomHeader/>
      <main className={styles.main}>
        <header>
          <CustomNavbar/>
        </header>
        <hr/>

        <div className="container-fluid p-5 mt-5" id="Presentation">
          <h1 className="display-4 font-weight-bold text-center">
            Ajouter un jardin
          </h1>
        </div>

        <Container className="gridgardens p-5">
            <Row>
                <Col>
                </Col>
            </Row>
            <Row>
                
            </Row>
        
        </Container>
      </main>
    </>
  );
}
