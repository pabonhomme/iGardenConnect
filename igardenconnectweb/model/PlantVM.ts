export class PlantVM {
    idPlant: number;
    name: string;
    species: string;
    wateringInterval?: Date;
    optimalTemperature?: number;
    soilMoisture?: number;
    airMoisture?: number;
    light?: number;

    
  constructor(
    idPlant: number,
    name: string,
    species: string,
    wateringInterval?: Date,
    optimalTemperature?: number,
    soilMoisture?: number,
    airMoisture?: number,
    light?: number,
  ) {
    this.idPlant = idPlant;
    this.name = name;
    this.species = species;
    this.wateringInterval = wateringInterval;
    this.optimalTemperature = optimalTemperature;
    this.soilMoisture = soilMoisture;
    this.airMoisture = airMoisture;
    this.light = light;
  }
}