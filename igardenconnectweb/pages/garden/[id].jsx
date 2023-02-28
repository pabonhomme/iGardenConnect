import styles from "@/styles/Home.module.css";
import { Container, Row, Col, Button } from "react-bootstrap";
import { useEffect, useState } from "react";
import { useRouter } from 'next/router'
import { GardenVM } from "../../model/GardenVM";
import Loading from "../../components/Loading";
import Forbidden from "../../components/Forbidden";

export default function Garden(props) {
  const router = useRouter();
  const { id } = router.query;
  const [loading, setLoading] = useState(true);
  const [garden, setGarden] = useState(new GardenVM());
  const [success, setSuccess] = useState(false);
  const [error, setError] = useState(null);

  function formatDate(datetime) {
    const dateObj = new Date(datetime);
    const hours = dateObj.getHours();
    const minutes = dateObj.getMinutes();
    const seconds = dateObj.getSeconds();
    const day = dateObj.getDate();
    const month = dateObj.getMonth() + 1;
    const year = dateObj.getFullYear();

    const formattedDate = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')} ${day.toString().padStart(2, '0')}/${month.toString().padStart(2, '0')}/${year}`;

    return formattedDate;
  }

  useEffect(() => {
    if (id === undefined) {
      return;
    }

    setLoading(true);

    const fetchData = () => {
      fetch(`http://localhost:5241/api/Garden/${id}`)
        .then((response) => {
          if (!response.ok) {
            throw new Error("Failed");
          }
          return response.json();
        })
        .then((garden) => {
          setGarden(garden);
          setLoading(false);
        })
        .catch((error) => {
          console.error(error);
        });
    };

    // Appel initial de l'API
    fetchData();

    // Appel de l'API toutes les 10 minutes
    const intervalId = setInterval(() => {
      fetchData();
    }, 5000);

    // Nettoyage de l'intervalle lorsqu'il n'est plus nécessaire
    return () => {
      clearInterval(intervalId);
    };
  }, [id]);


  function createGardenSensorList(garden) {
    return (
      <div className="row row-cols-2">
        {garden.gardenSensors?.map((sensor) => (
          <div key={sensor.idSensor} className="col-lg-6 col-md-6 col-sm-12 p-3">
            <div className="p-1" style={{ whiteSpace: "nowrap" }}>
              <strong>{sensor.name} :</strong>
              {(() => {
                switch (sensor.type) {
                  case "temperature":
                    return <span> {sensor.value} °C </span>;
                  case "airMoisture":
                    return <span> {sensor.value} % </span>;
                  case "soilMoisture":
                    return <span> {sensor.value} </span>;
                  case "waterlevel":
                    let waterLevelClass = "";
                    if (sensor.value > 75) {
                      waterLevelClass = "text-success";
                    } else if (sensor.value > 25) {
                      waterLevelClass = "text-warning";
                    } else {
                      waterLevelClass = "text-danger";
                    }
                    return (
                      <span className={waterLevelClass}> {sensor.value} % </span>
                    );
                  case "luminosity":
                    return <span> {sensor.value >= 5 ? "Ensoleillé" : "Peu ensoleillé"}
                    </span>;
                  case "pump":
                    return <span> {sensor.state} </span>;
                  case "led":
                    return <span> {sensor.state} </span>;
                  default:
                    return <span> {sensor.value} </span>;
                }
              })()}
            </div>
          </div>
        ))}
      </div>
    );
  }

  function deleteGarden(){
    event.preventDefault();
    const sessionCookie = document.cookie
        .split("; ")
        .find((row) => row.startsWith("sessionCookie="));
      const cookieValue = sessionCookie.split("=")[1];

      fetch(`http://localhost:5241/api/Garden/${id}`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
          Authorization: `${cookieValue}`,
        },
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

  if (props.user.idUser == undefined) {
    return (
      <>
        <main className={styles.main}>
          <Forbidden />
        </main>
      </>
    )
  }

  if (loading) {
    return (
      <>
        <main className={styles.main}>
          <Loading />
        </main>
      </>
    )
  }

  return (
    <>
      <main className={styles.main}>
        <hr />
        <Container className="my-5">
          <h1 className="text-center mb-4">Nom du jardin :{" "}{garden.name}</h1>

          <Row className="my-5 justify-content-center">
            <Col lg={4} md={3} className="p-3">
              <div className="cardinfogarden bg-light p-2">
                <h3 className="text-center border-bottom pb-2 mb-4">Informations sur le jardin</h3>
                <ul className="list-unstyled m-4">
                  <li className="mb-4">
                    <strong>Référence :</strong> {garden.idGarden}
                  </li>
                  <li className="mb-4">
                    <strong>Dernier arrosage :</strong> {formatDate(garden.lastWatered)}
                  </li>
                  <li className="mb-4">
                    <strong>Durée d'arrosage :</strong> {garden.wateringDuration}{" "}
                    secondes
                  </li>
                </ul>
              </div>
            </Col>
            <Col lg={4} md={3} className="p-3">
              <div className="cardinfogarden bg-light p-2">
                <h3 className="text-center border-bottom pb-2 mb-4">Capteurs</h3>
                {createGardenSensorList(garden)}
              </div>
            </Col>
            <Col lg={4} md={3} className="p-3 ">
              <div className="cardinfogarden bg-light p-2">
                <h3 className="text-center border-bottom pb-2 mb-4">Plante</h3>
                <ul className="list-unstyled m-4">
                  <li className="mb-4">
                    <strong>Nom :</strong> {garden.plant.name}
                  </li>
                  <li className="mb-4">
                    <strong>Espèce :</strong> {garden.plant.species}
                  </li>
                  <li className="mb-4">
                    <strong>Température optimale :</strong> {garden.plant.optimalTemperature}
                  </li>
                  <li className="mb-4">
                    <strong>Humidité du sol optimale :</strong> {garden.plant.soilMoisture}
                  </li>
                  <li className="mb-4">
                    <strong>Humidité de l'air optimale :</strong> {garden.plant.airMoisture}
                  </li>
                  <li className="mb-4">
                    <strong>Luminosité optimale :</strong> {garden.plant.light}
                  </li>
                </ul>
              </div>
            </Col>
          </Row>
          <div className="text-center">
          {error != null && (
                <p className="alert alert-danger mt-3">{error}</p>
              )}
              {success && (
                <p className="alert alert-success mt-3">Le jardin a été supprimé !</p>
              )}
            <Button className="btn btn-danger" onClick={deleteGarden}>Supprimer le jardin</Button>
          </div>
        </Container>
      </main>
    </>
  );
}
