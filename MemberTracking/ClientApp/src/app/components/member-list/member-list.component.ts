import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Alert } from 'src/app/models/alert';
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

  alert: Alert = new Alert();

  constructor(private memberService: MemberService) {}

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    this.members$ = this.memberService.getAllMembers();
  }

  resetAlert(): void {
    this.alert = new Alert();
  }

  setCurrentMember(member: Member): void {
    if (this.currentMember.id == 0) {
      Object.assign(this.currentMember, member);
    }
  }

  resetCurrentMember(): void {
    this.currentMember = new Member();
  }

  addOrUpdateMember(member: Member): void {
    if (member.id == 0) {
      this.addMember(member);
    } else {
      this.updateMember(member);
    }
  }

  addMember(member: Member) {
    this.memberService.addMember(member).subscribe((_) => {
      this.alert = new Alert('success', 'New Member added.');
      this.refreshList();
    });
  }

  updateMember(member: Member) {
    this.memberService
      .updateMember(this.currentMember.id, member)
      .subscribe((result) => {
        if (!result) {
          this.alert = new Alert(
            'failure',
            `Could not update Member with ID ${member.id}`
          );
        } else {
          this.alert = new Alert('success', 'Updated Member information.');
          this.refreshList();
        }
      });
  }

  deleteMember(id: number) {
    if (this.currentMember.id == id) {
      return;
    }

    this.memberService.deleteMember(id).subscribe((success) => {
      if (!success) {
        this.alert = new Alert(
          'failure',
          `Could not delete Member with ID ${id}`
        );
      } else {
        this.alert = new Alert('success', 'Member deleted.');
      }
      this.refreshList();
    });
  }
}
