import { GardenSensorVM } from "./GardenSensorVM";
import { PlantVM } from "./PlantVM";

export class GardenVM {
  idGarden?: string;
  name?: string;
  watered?: number;
  lastWatered?: Date;
  wateringDuration?: number;
  plant?: PlantVM;
  gardenSensors?: GardenSensorVM[];

  constructor(
    idGarden?: string,
    name?: string,
    watered?: number,
    lastWatered?: Date,
    wateringDuration?: number,
    plant?: PlantVM,
    gardenSensors?: []
  ) {
    this.idGarden = idGarden;
    this.name = name;
    this.watered = watered;
    this.lastWatered = lastWatered;
    this.wateringDuration = wateringDuration;
    this.plant = plant;
    this.gardenSensors = gardenSensors;
  }
}
