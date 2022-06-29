import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shipper } from '../models/shipperView';
import { Response } from '../models/response'

const httpOptions = {
  headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

@Injectable({
  providedIn: 'root'
})
export class ApishippersService {
  url: string = 'https://localhost:44362/api/Shippers';

  constructor(private http: HttpClient) {

   }
   getClientes(): Observable<Response>{
    return this.http.get<Response>(this.url);
  }
  InsertUpdateShipper(_shipper : Shipper):Observable<Response>{
    return this.http.post<Response>(this.url, _shipper, httpOptions);

  }
 //no necesito una solicitud put, dado que mi back responde para Insert and Update con una mismo IHttpActionResult mediante [httpost]
 //dado a una consigna de un anterior tp.
 /*updateShipper(shipper: Shipper): Observable<Response>{
  return this.http.put<Response>(this.url, shipper, httpOptions);
 }*/
 
  deleteShipper(id: number): Observable<Response>{
    return this.http.delete<Response>(`${this.url}/${id}`);
  }

  validationName(shipper : Shipper): Observable<Response>{
    return this.http.patch<Response>(this.url, shipper, httpOptions)
  }
}
