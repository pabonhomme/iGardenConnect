import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import CustomNavbar from "./components/CustomNavbar";
import CustomHeader from "./components/CustomHeader";
import {
  Container,
  Row,
  Col,
  Button,
} from "react-bootstrap";

const inter = Inter({ subsets: ["latin"] });

export default function Gardens() {
  return (
    <>
      <CustomHeader />
      <main className={styles.main}>
        <header>
          <CustomNavbar />
        </header>
        <hr />

        <div className="container-fluid p-5 mt-5" id="Presentation">
          <h1 className="display-4 font-weight-bold text-center">
            Liste des jardins
          </h1>
        </div>

        <Container className="gardensContainer mt-4">
          <Container className="gridgardens p-5">
            <Row className="justify-content-md-center">
              <Col>
                <div className="cardgardens">
                  <Row>
                    <Col xs={8}>
                      <div className="cardgardensHeader">
                        <h2 className="cardgardensTitle">Nom jardin</h2>
                      </div>
                      <div className="cardgardensBody">
                        <p className="cardgardensPlantType">Plante : Menthe</p>
                        <p className="cardgardensWateringStatus">
                          État : Watered
                        </p>
                      </div>
                    </Col>
                    <Col xs={4} className="d-flex align-items-center">
                      <span>&#x279C;</span>
                    </Col>
                  </Row>
                </div>
              </Col>
              <Col>
                <div className="cardgardens">
                  <Row>
                    <Col xs={8}>
                      <div className="cardgardensHeader">
                        <h2 className="cardgardensTitle">Nom jardin</h2>
                      </div>
                      <div className="cardgardensBody">
                        <p className="cardgardensPlantType">Plante : Menthe</p>
                        <p className="cardgardensWateringStatus">
                          État : Watered
                        </p>
                      </div>
                    </Col>
                    <Col xs={4} className="d-flex align-items-center">
                      <span>&#x279C;</span>
                    </Col>
                  </Row>
                </div>
              </Col>
              <Col>
                <div className="cardgardens">
                  <Row>
                    <Col xs={8}>
                      <div className="cardgardensHeader">
                        <h2 className="cardgardensTitle">Nom jardin</h2>
                      </div>
                      <div className="cardgardensBody">
                        <p className="cardgardensPlantType">Plante : Menthe</p>
                        <p className="cardgardensWateringStatus">
                          État : Watered
                        </p>
                      </div>
                    </Col>
                    <Col xs={4} className="d-flex align-items-center">
                      <span>&#x279C;</span>
                    </Col>
                  </Row>
                </div>
              </Col>
            </Row>
            <Row className="justify-content-md-center">
              <Col>
                <div className="cardgardens">
                  <Row>
                    <Col xs={8}>
                      <div className="cardgardensHeader">
                        <h2 className="cardgardensTitle">Nom jardin</h2>
                      </div>
                      <div className="cardgardensBody">
                        <p className="cardgardensPlantType">Plante : Menthe</p>
                        <p className="cardgardensWateringStatus">
                          État : Watered
                        </p>
                      </div>
                    </Col>
                    <Col xs={4} className="d-flex align-items-center">
                      <span>&#x279C;</span>
                    </Col>
                  </Row>
                </div>
              </Col>
              <Col>
                <div className="cardgardens">
                  <Row>
                    <Col xs={8}>
                      <div className="cardgardensHeader">
                        <h2 className="cardgardensTitle">Nom jardin</h2>
                      </div>
                      <div className="cardgardensBody">
                        <p className="cardgardensPlantType">Plante : Menthe</p>
                        <p className="cardgardensWateringStatus">
                          État : Watered
                        </p>
                      </div>
                    </Col>
                    <Col xs={4} className="d-flex align-items-center">
                      <span>&#x279C;</span>
                    </Col>
                  </Row>
                </div>
              </Col>
              <Col>
                <div className="cardgardens">
                  <Row>
                    <Col xs={8}>
                      <div className="cardgardensHeader">
                        <h2 className="cardgardensTitle">Nom jardin</h2>
                      </div>
                      <div className="cardgardensBody">
                        <p className="cardgardensPlantType">Plante : Menthe</p>
                        <p className="cardgardensWateringStatus">
                          État : Watered
                        </p>
                      </div>
                    </Col>
                    <Col xs={4} className="d-flex align-items-center">
                      <span>&#x279C;</span>
                    </Col>
                  </Row>
                </div>
              </Col>
            </Row>
          </Container>
          <Button className="submit-button bg-secondary" type="submit">
            Ajouter un jardin
          </Button>
        </Container>
      </main>
    </>
  );
}
