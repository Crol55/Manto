import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthService } from "./auth.service";
import { ListCreate } from "../common/models/listCreate.model";


@Injectable({
    providedIn: "root"
})
export class ListsService{

    private PORT:number = 7120;
    private URL:string = `https://localhost:${this.PORT}/lists`;

    private httpHeaders:HttpHeaders;

    constructor(private _httpClient: HttpClient, private _authService:AuthService)
    {
        this.httpHeaders = new HttpHeaders({
              Authorization: `Bearer ${this._authService.getAccessToken()}`
        });
    }

    public getLists(boardId: string){

        let endpoint = `${this.URL}/${boardId}`;

        return this._httpClient.get<ListCreate[]>(endpoint, {
            headers: this.httpHeaders,
            observe: 'response'
        })
    }

    public postNewList(listCreate: ListCreate){
        
        this._httpClient.post(this.URL, listCreate, {
            headers: this.httpHeaders
        }).subscribe(mydata => {console.log(mydata);});
    }
}