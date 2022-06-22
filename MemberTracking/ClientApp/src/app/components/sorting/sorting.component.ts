import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-sorting',
  templateUrl: './sorting.component.html',
  styleUrls: ['./sorting.component.css'],
})
export class SortingComponent implements OnInit {
  @Input() name!: string;
  @Input() sortStream!: Observable<string>;
  state: 'default' | 'asc' | 'desc' = 'default';
  @Output() sortingChange = new EventEmitter<string>();

  constructor() {}

  ngOnInit(): void {
    this.sortStream.subscribe(changedSort => {
      if (changedSort != this.name) {
        this.state = 'default';
      }
    })
  }

  toggleState() {
    if (this.state === 'default') {
      this.state = 'asc';
    } else if (this.state === 'asc') {
      this.state = 'desc';
    } else {
      this.state = 'default';
    }
    this.sortingChange.emit(this.state);
  }
}
