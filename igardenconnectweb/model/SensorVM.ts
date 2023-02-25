export class SensorVM {
  idSensor?: number;
  name: string;
  type: string;
  brand: string;
  price: string;

  constructor(idSensor: number | undefined, name: string, type: string, brand: string, price: string) {
    this.idSensor = idSensor;
    this.name = name;
    this.type = type;
    this.brand = brand;
    this.price = price;
  }  
}
