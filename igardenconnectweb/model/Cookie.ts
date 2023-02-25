export class Cookie {
  idUser: number;
  login: string;
  value: string;

  constructor(idUser: number, login: string, value: string) {
    this.value = value;
    this.idUser = idUser;
    this.login = login;
  }
}
