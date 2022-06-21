import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/app/models/member';
import { MemberService } from 'src/app/services/member.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css'],
})
export class MemberListComponent implements OnInit {
  members$!: Observable<Member[]>;
  currentMember: Member = new Member();

  alert: '' | 'success' | 'failure' = '';
  alertMessage: string = '';

  constructor(private memberService: MemberService) {}

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    this.members$ = this.memberService.getAllMembers();
  }

  resetAlert(): void {
    this.alert = '';
    this.alertMessage = '';
  }

  setCurrentMember(member: Member): void {
    if (this.currentMember.id == 0) {
      this.copyMember(member, this.currentMember);
    }
  }

  resetCurrentMember(): void {
    this.currentMember = new Member();
  }

  deleteMember(id: number) {
    if (this.currentMember.id == id) {
      return;
    }

    this.memberService.deleteMember(id).subscribe((success) => {
      if (!success) {
        this.alert = 'failure';
        this.alertMessage = `Could not delete Member with ID ${id}`;
      } else {
        this.alert = 'success';
        this.alertMessage = 'Member deleted.';
      }
      this.refreshList();
    });
  }

  private copyMember(from: Member, to: Member) {
    to.id = from.id;
    to.firstName = from.firstName;
    to.middleName = from.middleName;
    to.lastName = from.lastName;
  }
}
