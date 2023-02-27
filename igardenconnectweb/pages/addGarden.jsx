import { Inter } from "@next/font/google";
import React, { useState, useEffect } from "react";
import styles from "@/styles/Home.module.css";
import { getUserByToken } from "../utils/cookie";
import { GardenVM } from "../model/GardenVM";
import { PlantVM } from "../model/PlantVM";
import {
  Container,
  Form,
  Row,
  Col,
  Button,
} from "react-bootstrap";

const inter = Inter({ subsets: ["latin"] });

export default function AddGarden() {
  const [user, setUser] = useState(null); // null to verify if it worked before getting all gardens
  const [ref, setRef] = useState("");
  const [name, setName] = useState("");
  const [idPlant, setIdPlant] = useState(1);
  const [plant, setPlant] = useState(new PlantVM());
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(false);

  function handleRefChange(event) {
    setRef(event.target.value);
  }

  function handleNameChange(event) {
    setName(event.target.value);
  }

  function handlePlantChange(event) {
    setIdPlant(event.target.selectedIndex + 1);
  }

  useEffect(() => {
    async function fetchUser() {
      const user = await getUserByToken()
      setUser(user)
    }
    fetchUser()
  }, [])

  function onSubmit(event) {
    event.preventDefault();
    if (document.cookie && ref != "" && name != "") {

      // Créer une instance de SmallGardenVM avec les données du formulaire et la plante récupérée
      plant.idPlant = idPlant;
      plant.species = "";
      plant.name = "";
      const garden = new GardenVM(ref, name, 0, new Date(), 0, plant, []);
      // get cookie
      const sessionCookie = document.cookie
        .split("; ")
        .find((row) => row.startsWith("sessionCookie="));
      const cookieValue = sessionCookie.split("=")[1];

      fetch(`http://localhost:5241/api/Garden/${user.idUser}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `${cookieValue}`,
        },
        body: JSON.stringify(garden),
      })
        .then((response) => {
          if (!response.ok) {
            return response.text().then((errorMessage) => {
              throw new Error(errorMessage);
            });
          }
          setSuccess(true);
          setTimeout(() => {
            window.location.href = "http://localhost:3000/gardens";
          }, 1000); // Attendre 1 seconde (1000 millisecondes) avant de rediriger
        })
        .catch((error) => {
          setError(error.message);
        });
    }
  }


  return (
    <>
      <main className={styles.main}>
        <hr />

        <div className="container-fluid p-5 mt-5" id="Presentation">
          <h1 className="display-4 font-weight-bold text-center">
            Ajouter un jardin
          </h1>
        </div>

        <Container className="gridaddgardens p-5">
          <Form className="form-addContainer" onSubmit={onSubmit}>
            <Row>
              <Col>
                <Form.Group className="mb-3" controlId="formRefGarden">
                  <Form.Label className="addGardenLabel">
                    Référence du jardin :
                  </Form.Label>
                  <Form.Control
                    className="inputText"
                    required={true}
                    type="text"
                    placeholder="AERXCM"
                    onChange={handleRefChange}
                  />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formNameGarden">
                  <Form.Label className="addGardenLabel">
                    Nom du jardin :
                  </Form.Label>
                  <Form.Control
                    className="inputText"
                    required={true}
                    type="text"
                    placeholder="Menthe cuisine"
                    onChange={handleNameChange}
                  />
                </Form.Group>
              </Col>
              <Col className="d-flex align-items-center justify-content-center">
                <Form.Select className="selectPlant" onChange={handlePlantChange}>
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
              {error != null && (
                <p className="alert alert-danger mt-3">{error}</p>
              )}
              {success && (
                <p className="alert alert-success mt-3">Le jardin a été ajouté avec succès !</p>
              )}
              <Button className="submit-addGarden bg-secondary" type="submit" disabled={ref == "" || name == ""}>
                Ajouter
              </Button>
            </Row>
          </Form>
        </Container>
      </main>
    </>
  );
}
