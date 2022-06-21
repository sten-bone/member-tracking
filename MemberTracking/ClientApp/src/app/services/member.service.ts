import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../models/member';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private apiString = 'https://localhost:44389/api/members';

  constructor(private httpClient: HttpClient) {}

  public getAllMembers(): Observable<Member[]> {
    return this.httpClient.get<Member[]>(this.apiString);
  }

  public deleteMember(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.apiString}/${id}`);
  }
}
