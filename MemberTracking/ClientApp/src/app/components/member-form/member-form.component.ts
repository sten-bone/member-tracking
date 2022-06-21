import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Member } from 'src/app/models/member';
import { MemberService } from 'src/app/services/member.service';

@Component({
  selector: 'app-member-form',
  templateUrl: './member-form.component.html',
  styleUrls: ['./member-form.component.css'],
})
export class MemberFormComponent implements OnInit {
  @Input() member!: Member;
  @Output() resetForm = new EventEmitter();

  constructor(private memberService: MemberService) {}

  ngOnInit(): void {}

  setToDefault(): void {
    this.member = new Member();
    this.resetForm.emit();
  }

  addMember(): void {
    console.log(this.member.id, this.member.firstName);
    this.setToDefault();
  }
}
