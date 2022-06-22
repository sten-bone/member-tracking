import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Member } from 'src/app/models/member';

@Component({
  selector: 'app-member-form',
  templateUrl: './member-form.component.html',
  styleUrls: ['./member-form.component.css'],
})
export class MemberFormComponent implements OnInit {
  @Input() member!: Member;
  @Output() resetForm = new EventEmitter();
  @Output() addOrUpdateMember = new EventEmitter<Member>();

  ngOnInit(): void {}

  setToDefault(): void {
    this.member = new Member();
    this.resetForm.emit();
  }

  memberSubmit() {
    this.addOrUpdateMember.emit(this.member);
    this.setToDefault();
  }
}
