import Image from "next/image";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import { getUserByToken } from "../utils/cookie";
import GardenCard from "../components/GardenCard";
import { Container, Row, Col, Button } from "react-bootstrap";
import { useEffect, useState } from "react";

const inter = Inter({ subsets: ["latin"] });

export default function Gardens() {
  const [user, setUser] = useState(null); // null to verify if it worked before getting all gardens
  const [gardens, setGardens] = useState([]);

  async function getAllGardens(user) {
    // get cookie
    if (document.cookie) {
      // get cookie
      const sessionCookie = document.cookie
        .split("; ")
        .find((row) => row.startsWith("sessionCookie="));
      const cookieValue = sessionCookie.split("=")[1];
      console.log(user.idUser);
      const response = await fetch(
        `http://localhost:5241/api/Garden/user/${user.idUser}`,
        {
          method: "GET",
          headers: {
            Authorization: `${cookieValue}`,
          },
        }
      );
      const data = await response.json();
      return data;
    }
  }

  async function getUserAndGardens() {
    const user = await getUserByToken(); // getting the user by token
    const gardens = await getAllGardens(user);
    return { user, gardens };
  }

  useEffect(() => {
    getUserAndGardens()
      .then(({ user, gardens }) => {
        setUser(user);
        let allGardens = [];
        console.log(gardens);
        gardens.map((garden) => {
          allGardens.push(<GardenCard garden={garden} />);
        });
        setGardens(allGardens);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  // useEffect(() => {

  // }, []);

  return (
    <>
      <main className={styles.main}>
        <hr />

        <div className="container-fluid p-5 mt-5" id="Presentation">
          <h1 className="display-4 font-weight-bold text-center">
            Liste des jardins
          </h1>
        </div>

        <Container className="gardensContainer mt-4">
          <Container className="gridgardens p-5">
            {gardens}
            {/* <Row className="justify-content-md-center">
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
            </Row> */}
          </Container>
          <Button className="submit-button-gardens bg-secondary" type="submit">
            Ajouter un jardin
          </Button>
        </Container>
      </main>
    </>
  );
}
