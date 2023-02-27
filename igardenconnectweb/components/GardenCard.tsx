import Head from "next/head";
import { Inter } from "@next/font/google";
import { Container, Row, Col, Button } from "react-bootstrap";
import { GardenVM } from "../model/GardenVM";
import { useRouter } from 'next/router'


const inter = Inter({ subsets: ["latin"] });

export default function GardenCard({ garden }: { garden?: GardenVM }) {

  const router = useRouter();

  function handleClick() {
    const idGarden = document.getElementById(`garden-id-${garden?.idGarden}`)?.textContent;
    router.push(`/garden/${idGarden}`);
  }

  return (
    <>
      <div className="cardgardens" onClick={handleClick}>
        <Row>
          <Col xs={8}>
            <div className="cardgardensHeader">
              <h2 className="cardgardensTitle">{garden?.name}</h2>
              <div className="d-none" id={`garden-id-${garden?.idGarden}`}>
                {garden?.idGarden}
              </div>
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
