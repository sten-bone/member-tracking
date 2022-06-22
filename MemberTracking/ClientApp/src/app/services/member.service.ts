import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
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

  public addMember(member: Member): Observable<any> {
    return this.httpClient.post(this.apiString, member);
  }

  public updateMember(id: number, member: Member): Observable<boolean> {
    return this.httpClient.post<boolean>(`${this.apiString}/${id}`, member);
  }

  public deleteMember(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.apiString}/${id}`);
  }
}
