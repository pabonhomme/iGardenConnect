import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";
import { Container, Row, Col, Button } from "react-bootstrap";

export default function Garden() {
  // Données factices
  const garden = {
    reference: "AERXCM",
    name: "Menthe cuisine",
    lastWatering: "2022-02-15 14:30:00",
    wateringDuration: 20,
  };

  const sensors = {
    brightness: 80,
    humidity: 60,
    soilMoisture: 50,
    temperature: 22,
    pumpActive: true,
    ledActive: false,
    waterLevel: 30,
  };

  const plant = {
    name: "Menthe",
    species: "Mentha spicata",
    optimalWateringDuration: 30,
    requiredTemperature: 18,
    requiredSunDuration: 6,
  };

  return (
    <>
      <CustomHeader />
      <main className={styles.main}>
        <CustomNavbar />
        <hr />
        <Container className="my-5">
          <h1 className="text-center mb-4">{garden.name}</h1>
          <Row className="my-5">
            <Col md={4} className="mb-4 mb-md-0">
              <h3>Informations sur le jardin</h3>
              <ul className="list-unstyled">
                <li>
                  <strong>Référence :</strong> {garden.reference}
                </li>
                <li>
                  <strong>Dernier arrosage :</strong> {garden.lastWatering}
                </li>
                <li>
                  <strong>Durée d'arrosage :</strong> {garden.wateringDuration}{" "}
                  secondes
                </li>
              </ul>
            </Col>
            <Col md={4} className="mb-4 mb-md-0">
              <h3>Capteurs</h3>
              <ul className="list-unstyled">
                <li>
                  <strong>Luminosité :</strong> {sensors.brightness}%
                </li>
                <li>
                  <strong>Humidité :</strong> {sensors.humidity}%
                </li>
                <li>
                  <strong>Humidité du sol :</strong> {sensors.soilMoisture}%
                </li>
                <li>
                  <strong>Température :</strong>
                </li>

                <li>
                  <strong>Niveau d'eau :</strong> {sensors.waterLevel}%
                </li>
              </ul>
            </Col>
            <Col md={4}>
              <h3>Plante</h3>
              <ul className="list-unstyled">
                <li>
                  <strong>Nom :</strong> {plant.name}
                </li>
                <li>
                  <strong>Espèce :</strong> {plant.species}
                </li>
                <li>
                  <strong>Durée d'arrosage optimal :</strong>{" "}
                  {plant.optimalWateringDuration} secondes
                </li>
                <li>
                  <strong>Température requise :</strong>{" "}
                  {plant.requiredTemperature}°C
                </li>
                <li>
                  <strong>Durée de soleil requise :</strong>{" "}
                  {plant.requiredSunDuration} heures
                </li>
              </ul>
            </Col>
          </Row>
          <div className="text-center">
            <Button variant="primary">Arroser</Button>
          </div>
        </Container>
      </main>
    </>
  );
}
