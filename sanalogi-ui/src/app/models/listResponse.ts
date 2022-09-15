import { ResponseModel } from "./response";

export class ListResponseModel<T> extends ResponseModel{
  data: T[];
}
