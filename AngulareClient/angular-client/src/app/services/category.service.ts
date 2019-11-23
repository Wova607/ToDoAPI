import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable()
export class CategoryService
{
 baseURL ="https://localhost:44348/Category/";
 constructor(private http: HttpClient){}

 getAllCategory(): Observable<any>{
    return this.http.get(this.baseURL+"GetAllCategory");
 }

addCategory(name: string): Observable<any>{
    
return this.http.post(this.baseURL+"AddCategory",name);
}

delCategory(id:number): Observable<any>{
    
    return this.http.delete(this.baseURL+"DeletCategory")
}


}

 
