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
            <div className="cardgardensBody d-flex flex-column justify-content-between">
              <div className="cardgardensPlantType mb-3">
                <img src="/plante.png" alt="plante" className="mr-2"/>
                {" " + garden?.plant?.name}
              </div>
              <div className="cardgardensPlantType">
                <img src="/arrosoir.png" alt="plante" className="mr-2"/>
                {garden?.watered ? "  Arrosage en cours" : "  Arrosage terminé"}  
              </div>
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
