import Head from "next/head";
import { Inter } from "@next/font/google";
import { Container, Row, Col, Button } from "react-bootstrap";

const inter = Inter({ subsets: ["latin"] });

export default function CustomHeader() {
  return (
    <>
      <div className="cardgardens">
        <Row>
          <Col xs={8}>
            <div className="cardgardensHeader">
              <h2 className="cardgardensTitle">Nom jardin</h2>
            </div>
            <div className="cardgardensBody">
              <p className="cardgardensPlantType">Plante : Menthe</p>
              <p className="cardgardensWateringStatus">État : Watered</p>
            </div>
          </Col>
          <Col xs={4} className="d-flex align-items-center">
            <span>&#x279C;</span>
          </Col>
        </Row>
      </div>
    </>
  );
}
