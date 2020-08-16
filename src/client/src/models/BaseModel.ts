import { validate, ValidationError } from "class-validator";

export default abstract class BaseModel {

  public errors: Object;

  constructor() {
    this.errors = {};
  }

  public get isValid(): boolean {
    return Object.keys(this.errors).length === 0;
  }

  public async validateModel()  {
    let result = await validate(this);
    this.errors = this.setError(result)
  }

  public setError(result: ValidationError[]): Object {
    let propBag = {};

    for (const error of result) {
      for (const key in error.constraints) {
        if (Object.prototype.hasOwnProperty.call(error.constraints, key)) {
           const msg = error.constraints[key];
          (propBag as any)[error.property] = msg;
        }
      } 
    }

    return propBag; 

  }
}