import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import { Navbar, Nav } from "react-bootstrap";
import { UserVM } from "../model/UserVM";

const inter = Inter({ subsets: ["latin"] });

export default function CustomNavbar({ user }: { user: UserVM }) {

  function logout() {
    let cookies = document.cookie.split("; ");
    let sessionCookie = cookies.find((row) => row.startsWith("sessionCookie="));
    if (sessionCookie) {
        document.cookie = `${sessionCookie}; max-age=0`;
    }
    window.location.href = "http://localhost:3000/";
  }

  if (user.login) {
    return (
      <>
        <Navbar bg="dark" expand="md" fixed="top" variant="dark">
          <Navbar.Brand href="/" className="ms-5">
            <img
              alt=""
              src="/logoiGarden.png"
              width="80"
              height="35"
              className="d-inline-block align-top"
            />{" "}
            iGardenConnect
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="ms-auto"></Nav>
            <Nav>
              <Nav.Link href="#">Bonjour {user.login}</Nav.Link>
              <Nav.Link href="/gardens">Mes jardins</Nav.Link>
              <Nav.Link onClick={logout} href="#">Se déconnecter</Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Navbar>
      </>
    );
  } else {
    return (
      <>
        <Navbar bg="dark" expand="md" fixed="top" variant="dark">
          <Navbar.Brand href="/" className="ms-5">
            <img
              alt=""
              src="/logoiGarden.png"
              width="80"
              height="35"
              className="d-inline-block align-top"
            />{" "}
            iGardenConnect
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="ms-auto"></Nav>
            <Nav>
              <Nav.Link href="/login">Connexion</Nav.Link>
              <Nav.Link href="/createAccount">Créer un compte</Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Navbar>
      </>
    );
  }
}
