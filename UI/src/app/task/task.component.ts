import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Task, TaskModelToEdit } from '../models/task.model';
import {TaskService} from './task.service';
import {Service} from '../app.service';
import {Checklist} from '../models/Checklist.model';
import {TodoItem, TodoItemModel} from '../models/TodoItem.model';
import {List} from '../models/list';

const input = Input;

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  // tslint:disable-next-line:variable-name
  private _visible: boolean;
  employees: any[] = [];
  visibleWarring = false;
  withShadingOptionsVisible = false;
  nameTitleChecklist: string;
  nameTodoItem: string;

  @Input()
  get visible(): boolean {
    return this._visible;
  }

  set visible(value: boolean) {
    this._visible = value;
    this.visibleChange.emit(value);
  }

  @Input() task: Task;

  @Input() lists: List[] = [];

  @Output() visibleChange = new EventEmitter<boolean>();

  allowEditing = true;

  today: Date = new Date();

  constructor(public taskService: TaskService, public service: Service) {
    taskService.GetEmployees().subscribe((employees) => {
      employees.forEach(employee => this.employees.push(employee));

      if (this.employees && this.employees.length) {
        if (!this.task.assignedEmployeeId) {
          this.task.assignedEmployeeId = this.employees[0].id;
        }
        if (!this.task.ownerId) {
          this.task.ownerId = this.employees[0].id;
        }
      }
    });
  }

  ngOnInit() {
  }

  close() {
    this.visible = false;
  }

  saveTask() {
    if (this.task.name != null) {
      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.CreateTask(this.task).subscribe((data) => {
        const list = this.lists.filter(_ => _.id === data.listId)[0];
        list.tasks.push(data);
        // this.onTaskChange.emit();
      });
    }
  }

  deleteTask() {
    // tslint:disable-next-line:no-shadowed-variable
    this.taskService.DeleteTask(this.task.id).subscribe((data) => {
      const list = this.lists.filter(_ => _.id === this.task.listId)[0];
      const index = list.tasks.findIndex(obj => obj.id === this.task.id);
      list.tasks.splice(index, 1);
      this.visibleWarring = false;
      this.visible = false;
    });
  }

  showWarring() {
    this.visibleWarring = true;
  }

  closeWarring() {
    this.visibleWarring = false;
  }

  toggleWithShadingOptions() {
    this.withShadingOptionsVisible = !this.withShadingOptionsVisible;
  }

  editChecklist(e, checklist: Checklist) {
    if (this.task.id) {
      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateChecklist(checklist.id, checklist).subscribe((data) => {
      });
    }
    this.focusOutTitle(e);
  }

  deleteChecklist(id) {
    // tslint:disable-next-line:no-shadowed-variable
    this.taskService.DeleteChecklist(id).subscribe((data) => {
      const index = this.task.checklist.findIndex(obj => obj.id === id);
      this.task.checklist.splice(index, 1);
    });
  }

  saveChecklist() {
    if (this.nameTitleChecklist != null) {
      this.task.checklist = this.task.checklist || [];
      const checklist = new Checklist();
      checklist.name = this.nameTitleChecklist;
      checklist.taskId = this.task.id;
      if (this.task.id) {
        // tslint:disable-next-line:no-shadowed-variable
        this.taskService.CreateChecklist(checklist).subscribe((data) => {
          this.task.checklist.push(data);
        });
      } else {
        this.task.checklist.push(checklist);
      }
      this.nameTitleChecklist = '';
    }

    this.withShadingOptionsVisible = !this.withShadingOptionsVisible;
  }

  editTodoItemName(e, todoItem: TodoItem) {
    if (this.task.id) {
      const todoItemModel = new TodoItemModel<string>();
      todoItemModel.id = todoItem.id;
      todoItemModel.value = todoItem.name;
      todoItemModel.checklistId = todoItem.checklistId;
      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateTodoItemName(todoItemModel).subscribe((data) => {
      });
    }
    this.focusOutTitle(e);
  }

  editTodoItemStatus(todoItem: TodoItem) {
    const todoItemModel = new TodoItemModel<boolean>();
    todoItemModel.id = todoItem.id;
    todoItemModel.value = todoItem.isActive;
    todoItemModel.checklistId = todoItem.checklistId;
    if (this.task.id) {
      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateTodoItemStatus(todoItemModel).subscribe((data) => {
      });
    }
  }

  deleteTodoItem(id: number, todoItems: TodoItem[]) {
    // tslint:disable-next-line:no-shadowed-variable
    this.taskService.DeleteTodoItem(id).subscribe((data) => {
      const index = todoItems.findIndex(obj => obj.id === id);
      todoItems.splice(index, 1);
    });
  }

  addItemTodo(e, checklist: Checklist) {
    const todoItem = new TodoItem();
    todoItem.name = this.nameTodoItem;
    todoItem.checklistId = checklist.id;
    checklist.todoItem = checklist.todoItem || [];

    if (this.task.id) {
      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.CreateTodoItem(todoItem).subscribe((data) => {
        todoItem.id = data.id;
        checklist.todoItem.push(todoItem);
      });
    } else {
      checklist.todoItem.push(todoItem);
    }

    this.nameTodoItem = '';
    e.element.style.display = 'none';
    e.element.previousSibling.style.display = 'block';
  }

  showTextBoxAddTodoItem(e) {
    e.toElement.style.display = 'none';
    e.toElement.nextSibling.style.display = 'block';
  }

  onBlurTodoItem(e) {
    e.element.style.display = 'none';
    e.element.previousSibling.style.display = 'block';
  }

  focusInTitle(e) {
    e.element.style.border = '1px solid black';
    e.element.style.background = '#fff';
  }

  focusOutTitle(e) {
    e.element.style.border = '1px solid rgba(0,0,0,0)';
    e.element.style.background = '#f4f5f7';
  }

  editTitle(e) {
    if (this.task.id) {
      const model = new TaskModelToEdit<string>();
      model.id = this.task.id;
      model.value = this.task.name;

      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateTaskName(model).subscribe((data) => {
      });
    }
    this.focusOutTitle(e);
  }

  editStartDate() {
    if (this.task.id) {
      const model = new TaskModelToEdit<Date>();
      model.id = this.task.id;
      model.value = this.task.startDate;

      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateTaskStartDate(model).subscribe((data) => {
      });
    }
  }

  editDuaDate() {
    if (this.task.id) {
      const model = new TaskModelToEdit<Date>();
      model.id = this.task.id;
      model.value = this.task.dueDate;

      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateTaskDuaDate(model).subscribe((data) => {
      });
    }
  }

  editAssignEmployee() {
    if (this.task.id) {
      const model = new TaskModelToEdit<number>();
      model.id = this.task.id;
      model.value = this.task.assignedEmployeeId;

      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateTaskAssignEmployee(model).subscribe((data) => {
      });
      // Get employee
      this.taskService.GetEmployee(this.task.assignedEmployeeId).subscribe((data) => {
        this.task.assignedEmployee = data;
      });
    }
  }

  editOwner() {
    if (this.task.id) {
      const model = new TaskModelToEdit<number>();
      model.id = this.task.id;
      model.value = this.task.ownerId;

      // tslint:disable-next-line:no-shadowed-variable
      this.taskService.UpdateTaskOwner(model).subscribe((data) => {
      });
      // Get owner by id
      this.taskService.GetEmployee(this.task.ownerId).subscribe((data) => {
        this.task.owner = data;
      });
    }
  }
}

