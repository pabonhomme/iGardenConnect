import React, { FormEvent } from "react";
import { Inter } from "@next/font/google";
import styles from "@/styles/Home.module.css";
import Link from "next/link";
import { setSessionCookie } from "../utils/cookie";

import { useState } from "react";
import CustomNavbar from "../components/CustomNavbar";
import CustomHeader from "../components/CustomHeader";
import { Form, Button, Container } from "react-bootstrap";
import { UserVM } from "../model/UserVM";

export default function Login() {
  let login = "";
  let password = "";
  const user = new UserVM();
  const bcrypt = require("bcryptjs");

  const [loading, setLoading] = useState(false);

  // function showError(id) {
  //   document.getElementById(id).classList.add("shake");
  //   document.getElementById(id).innerHTML = "Error";
  //   setTimeout(() => {
  //     document.getElementById(id).classList.remove("shake");
  //   }, 500);

  //   setTimeout(() => {
  //     document.getElementById(id).innerHTML = "";
  //   }, 5000);
  // }

  function handleLoginChange(event) {
    login = event.target.value;
  }

  function handlePasswordChange(event) {
    password = event.target.value;
  }

  function onsubmit(event) {
    event.preventDefault();

    fetch(`http://localhost:5241/api/User/auth/${login}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => {
        if (response.ok) {
          console.log(response);
          return response.json(); // récupérer les données JSON dans la réponse
        } else {
          throw new Error("User not found");
        }
      })
      .then((userData) => {
        console.log(userData);
        // créer une instance de UserVM à partir des données JSON récupérées
        const user = new UserVM(
          userData.idUser,
          userData.login,
          userData.role,
          userData.password
        );
        console.log(user);
        if (bcrypt.compareSync(password, user.password)) {
          // const sessionCookie = generateNewCookie(user.idUser, user.login);
          // document.cookie = `sessionCookie=${sessionCookie}; max-age=86400`;
          setSessionCookie(user);
          window.location.href = "http://localhost:3000/";
        } else {
          throw new Error("Password is wrong");
        }
      })
      .catch((error) => {
        console.error(error);
      });
  }

  return (
    <>
      <main className={styles.main}>
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
                onChange={handleLoginChange}
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
