import React, { FormEvent } from "react";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import Link from "next/link";

import { useState } from "react";
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";
import { Form, Button, Container } from "react-bootstrap";

export default function Login() {
  let username = "";
  let email = "";
  let password = "";

  const [loading, setLoading] = useState(false);

  function showError(id) {
    document.getElementById(id).classList.add("shake");
    document.getElementById(id).innerHTML = "Error";
    setTimeout(() => {
      document.getElementById(id).classList.remove("shake");
    }, 500);

    setTimeout(() => {
      document.getElementById(id).innerHTML = "";
    }, 5000);
  }

  function handleUsernameChange(event) {
    username = event.target.value;
  }

  function handlePasswordChange(event) {
    password = event.target.value;
  }

  function onsubmit(event) {
    // event.preventDefault();
    // const user = {
    //   username: username,
    //   passwd: password,
    // };
    // setLoading(true);
    // fetch("http://localhost:8001/api/users/login", {
    //   method: "POST",
    //   headers: {
    //     "Content-Type": "application/json",
    //   },
    //   body: JSON.stringify(user),
    // })
    //   .then((response) => response.json())
    //   .then((data) => {
    //     try {
    //       const sessionCookie = data.cookie;
    //       document.cookie = `sessionCookie=${sessionCookie.value}; max-age=86400`;
    //       window.location.href = "http://localhost:3000/home";
    //     } catch (error) {
    //       showError("error");
    //     } finally {
    //       setLoading(false);
    //     }
    //   });
  }

  //   if (loading) {
  //     return (
  //       <>
  //         <div className="loading-container">
  //           <div className="lds-dual-ring"></div>
  //           <div className="loading">Loading...</div>
  //           <div className="error" id="error"></div>
  //         </div>
  //       </>
  //     );
  //   }

  return (
    <>
      <CustomHeader />
      <main className={styles.main}>
        <header>
          <CustomNavbar />
        </header>
        <hr />
        <div className="login-container p-5">
          <h2>Se connecter</h2>
          <Form className="form-login" onSubmit={onsubmit}>
            <Form.Group className="mb-3" controlId="formBasiclogin">
              <Form.Label className="login-text">
                Entrer votre login :
              </Form.Label>
              <Form.Control
                className="inputText"
                type="text"
                placeholder="mon pseudo"
                onChange={handleUsernameChange}
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label className="login-text">
                Entrer votre mot de passe :
              </Form.Label>
              <Form.Control
                className="inputText"
                type="password"
                placeholder="********"
                onChange={handlePasswordChange}
              />
            </Form.Group>

            <Button
              className="submit-button-connexion bg-secondary"
              type="submit"
            >
              Se connecter
            </Button>
            <p id="error" style={{ color: "red" }}></p>
          </Form>
          <Container className="mt-4">
            <h6>Pas encore de compte ?</h6>
            <Link href="/createAccount">
                <Button className="submit-button-createAccount-connexion bg-secondary">
                  Créer un compte
                </Button>
            </Link>
          </Container>
        </div>
      </main>
    </>
  );
}
