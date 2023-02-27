import { UserVM } from "@/model/UserVM";
import { Cookie } from "../model/Cookie";

export function setSessionCookie(user) {
  fetch(`http://localhost:5241/api/User/cookie/${user.idUser}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to retrieve session cookie");
      }
      return response.json();
    })
    .then((cookie) => {
      // Ajouter le cookie à document.cookie
      document.cookie = `sessionCookie=${cookie.value};expires=${cookie.expires};path=/`;
    })
    .catch((error) => {
      console.error(error);
    });
}

export async function getUserByToken() {
  return new Promise(async (resolve, reject) => {
    let user = new UserVM();
    if (document.cookie) {
      // get cookie
      const sessionCookie = document.cookie
        .split("; ")
        .find((row) => row.startsWith("sessionCookie="));
      const cookieValue = sessionCookie.split("=")[1];

      if (cookieValue) {
        const response = await fetch(`http://localhost:5241/api/user/cookie/${cookieValue}`, {
          method: "POST",
        });        
        if (response.status === 200) {
          user = response.json();
        }
      }
    }
    resolve(user);
  });
}
