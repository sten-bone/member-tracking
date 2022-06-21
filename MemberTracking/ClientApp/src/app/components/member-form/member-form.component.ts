import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/models/member';
import { MemberService } from 'src/app/services/member.service';

@Component({
  selector: 'app-member-form',
  templateUrl: './member-form.component.html',
  styleUrls: ['./member-form.component.css']
})
export class MemberFormComponent implements OnInit {
  @Input() member!: Member;

  constructor(private memberService: MemberService) { }

  ngOnInit(): void {}

  setToDefault(): void {
    this.member = new Member;
  }

}
