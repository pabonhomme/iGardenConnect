import Head from "next/head";
import { Inter } from "@next/font/google";
import { Container, Row, Col, Button } from "react-bootstrap";
import { SmallGardenVM } from "../model/SmallGardenVM";

const inter = Inter({ subsets: ["latin"] });

export default function GardenCard({ garden }: { garden?: SmallGardenVM }) {
  return (
    <>
      <div className="cardgardens">
        <Row>
          <Col xs={8}>
            <div className="cardgardensHeader">
              <h2 className="cardgardensTitle">{garden?.name}</h2>
            </div>
            <div className="cardgardensBody">
              <p className="cardgardensPlantType">Plante : {garden?.plant?.name}</p>
              <p className="cardgardensWateringStatus">État : {garden?.watered}</p>
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
