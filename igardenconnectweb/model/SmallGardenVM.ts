import { PlantVM } from "./PlantVM";

export class SmallGardenVM {
  idGarden?: string;
  name?: string;
  watered?: number;
  lastWatered?: Date;
  wateringDuration?: number;
  plant?: PlantVM;

  constructor(
    idGarden?: string,
    name?: string,
    watered?: number,
    lastWatered?: Date,
    wateringDuration?: number,
    plant?: PlantVM
  ) {
    this.idGarden = idGarden;
    this.name = name;
    this.watered = watered;
    this.lastWatered = lastWatered;
    this.wateringDuration = wateringDuration;
    this.plant = plant;
  }
}
