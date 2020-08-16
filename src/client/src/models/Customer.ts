import BaseModel from './BaseModel';
import { IsDefined, MinLength, Matches, IsPhoneNumber, IsOptional, Length} from 'class-validator';

export default class Customer extends BaseModel {
  id = 0;
  fullName: string | undefined;

  @MinLength(3, {
    message: "Must be > 3 characters"
  })
  firstName: string | undefined;

  @MinLength(5, {
    message: "Must be > 5 characters"
  })
  lastName: string | undefined;

  @IsOptional()
  @IsPhoneNumber("US", { message: "Must be a valid phone number"})
  phoneNumber: string | undefined;

  @IsOptional()
  @MinLength(5, {
    message: "Must be > 5 characters"
  })
  companyName: string | undefined;
  
  @IsDefined({
    message: "Address is required"
  })
  addressLine1: string | undefined;
  
  addressLine2: string | undefined;
  addressLine3: string | undefined;
  
  @IsDefined({
    message: "City is required"
  })
  cityTown: string | undefined;

  @IsDefined({
    message: "State is required"
  })
  @Length(2, 2, {
    message: "Must be a US State"
  })
  stateProvince: string | undefined;

  @IsDefined({
    message: "Zipcode is required"
  })
  @Matches(/^[0-9]{5}(?:-[0-9]{4})?$/, {
    message: "Must be valid Zipcode"
  })
  postalCode: string | undefined;

}
