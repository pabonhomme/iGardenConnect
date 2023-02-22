import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";
import {
  Container,
  Form,
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
      <CustomHeader />
      <main className={styles.main}>
        <header>
          <CustomNavbar />
        </header>
        <hr />

        <div className="container-fluid p-5 mt-5" id="Presentation">
          <h1 className="display-4 font-weight-bold text-center">
            Ajouter un jardin
          </h1>
        </div>

        <Container className="gridaddgardens p-5">
          <Form className="form-addContainer" onSubmit="">
            <Row>
              <Col>
                <Form.Group className="mb-3" controlId="formRefGarden">
                  <Form.Label className="addGardenLabel">
                    Référence du jardin :
                  </Form.Label>
                  <Form.Control
                    className="inputText"
                    type="text"
                    placeholder="AERXCM"
                    onChange=""
                  />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formNameGarden">
                  <Form.Label className="addGardenLabel">
                    Nom du jardin :
                  </Form.Label>
                  <Form.Control
                    className="inputText"
                    type="text"
                    placeholder="Menthe cuisine"
                    onChange=""
                  />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formWateringDuration">
                  <Form.Label className="addGardenLabel">
                    Durée d'arrosage :
                  </Form.Label>
                  <Form.Control
                    className="inputText"
                    type="text"
                    placeholder="Nombre de secondes. Exemple : 20"
                    onChange=""
                  />
                </Form.Group>
              </Col>
              <Col className="d-flex align-items-center justify-content-center">
                <Form.Select className="selectPlant">
                  <option>Menthe</option>
                  <option>Basilic</option>
                  <option>Rose</option>
                  <option>Persil</option>
                  <option>Coriandre</option>
                  <option>Romarin</option>
                </Form.Select>
              </Col>
            </Row>
            <Row className="justify-content-center mt-3">
              <Button className="submit-addGarden bg-secondary" type="submit">
                Ajouter
              </Button>
            </Row>
          </Form>
        </Container>
      </main>
    </>
  );
}
