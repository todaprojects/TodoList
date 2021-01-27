import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { TodoService } from '../../../../services/todo.service';

import { Todo } from '../../../../models/Todo';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.scss']
})
export class TodoItemComponent implements OnInit {
  @Input() todo: Todo;
  @Output() deleteTodo: EventEmitter<Todo> = new EventEmitter();

  constructor(private todoService: TodoService) {
  }

  ngOnInit(): void {
  }

  // Set Dynamic classes
  setClasses() {
    return {
      todo: true,
      'is-complete': this.todo.completed
    };
  }

  onToggle(todo: Todo) {
    // Toggle in UI
    this.todo.completed = !todo.completed;
    // Toggle on server
    this.todoService.toggleCompleted(todo).subscribe();
  }

  onDelete(todo: Todo) {
    this.deleteTodo.emit(todo);
  }
}
