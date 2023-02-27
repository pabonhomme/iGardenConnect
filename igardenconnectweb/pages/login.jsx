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
  
  const bcrypt = require("bcryptjs");
  const [login, setLogin] = useState("");
  const [error, setError] = useState(null);
  const [password, setPassword] = useState("");
  const [success, setSuccess] = useState(false);

  function handleLoginChange(event) {
    setLogin(event.target.value);
  }

  function handlePasswordChange(event) {
    setPassword(event.target.value);
  }

  async function onsubmit(event) {
    event.preventDefault();
  
    try {
      const response = await fetch(`http://localhost:5241/api/User/auth/${login}`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      });
  
      if (!response.ok) {
        throw new Error("User not found");
      }
  
      const userData = await response.json();
      const user = new UserVM(
        userData.idUser,
        userData.login,
        userData.role,
        userData.password
      );
  
      if (bcrypt.compareSync(password, user.password)) {
        await setSessionCookie(user); // wait for the cookie to be set
        setSuccess(true);
        setTimeout(() => {
          window.location.href = "http://localhost:3000/";
        }, 1000); // Attendre 1 seconde (1000 millisecondes) avant de rediriger
      } else {
        throw new Error("Password is wrong");
      }
    } catch (error) {
      setError(error.message);
    }
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
                required={true}
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
                required={true}
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
            {error!=null && (
                <p className="alert alert-danger mt-3">{error}</p>
              )}
            {success && (
                <p className="alert alert-success mt-3">Connexion réussie</p>
              )}
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
