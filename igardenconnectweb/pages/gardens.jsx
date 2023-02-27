import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import GardenCard from "../components/GardenCard";
import { Container, Row, Col, Button } from "react-bootstrap";
import { useEffect, useState } from "react";
import Loading from "../components/Loading";
import Forbidden from "../components/Forbidden";

const inter = Inter({ subsets: ["latin"] });

export default function Gardens(props) {
  const [gardens, setGardens] = useState(null);
  const [noGardens, setNoGardens] = useState(null);
  const [loading, setLoading] = useState(true);

  async function getAllGardens(user) {
    // get cookie
    if (document.cookie) {
      // get cookie
      const sessionCookie = document.cookie
        .split("; ")
        .find((row) => row.startsWith("sessionCookie="));
      const cookieValue = sessionCookie.split("=")[1];

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
      console.log(data);
      return data;
    }
  }

  async function getUserAndGardens(user) {
    //const user = await getUserByToken(); // getting the user by token
    const gardens = await getAllGardens(user);
    return { gardens };
  }

  useEffect(() => {
    getUserAndGardens(props.user).then(({ gardens }) => {
      if (gardens.length === 0) {
        setNoGardens(<Row className="justify-content-md-center">
          <div>Vous n'avez aucun jardin</div>
        </Row>);
      } else {
        const allGardens = gardens.map((garden) => {
          return <Col key={garden.idGarden} xs={4}><GardenCard garden={garden} /></Col>
        });
        
        const gardenRows = [];
        
        for (let i = 0; i < allGardens.length; i += 3) {
          gardenRows.push(
            <Row className="justify-content-md-center" key={i}>
              {allGardens.slice(i, i + 3)}
            </Row>
          );
        }        

        setGardens(gardenRows);
        setLoading(false);
      }
    }).catch((error) => {
      console.log(error);
    });
  }, [props]);

  if(props.user.idUser == undefined){
    return (
      <>
        <main className={styles.main}>
          <Forbidden/>
        </main>
      </>
    )
  }

  if (loading) {
    return (
      <>
        <main className={styles.main}>
          <Loading/>
        </main>
      </>
    )
  }

  return (
    <>
      <main className={styles.main}>
        <hr />

        <div className="container-fluid p-5 mt-5" id="Presentation">
          <h1 className="display-4 font-weight-bold text-center">
            Liste des jardins
          </h1>
        </div>

        <Container className="gardensContainer mt-4 mb-4">
          {noGardens && (<Container className="gridNogardens p-5">
            {noGardens}
          </Container>)}
          {gardens && (<Container className="gridgardens p-5">
            {gardens}
          </Container>)}
          <Button className="submit-button-gardens bg-secondary" type="submit" href="/addGarden">
            Ajouter un jardin
          </Button>
        </Container>
      </main>
    </>
  );
}
