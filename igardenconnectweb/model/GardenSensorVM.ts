import { SensorVM } from './SensorVM';

export class GardenSensorVM extends SensorVM {
    value?: string;
    state?: string;
  
    constructor(
      idSensor: number | undefined,
      name: string,
      type: string,
      brand: string,
      price: string,
      value: string | undefined,
      state: string | undefined
    ) {
      super(idSensor, name, type, brand, price);
      this.value = value;
      this.state = state;
    }
  }
  