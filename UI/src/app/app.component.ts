import { Component} from '@angular/core';
import {Task} from '../app/models/task.model';
import { Service } from './app.service';
import {TaskService} from './task/task.service';
import {List, ListModel} from './models/list';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  preserveWhitespaces: true
})

export class AppComponent {
  lists: List[] = [];
  task: Task;
  popupVisible = false;
  //
  constructor(public service: Service, public taskService: TaskService) {
    service.GetList().subscribe((lists) => {
      this.lists = lists || [];
    });
  }

  onListReorder(e) {
    const list = this.lists.splice(e.fromIndex, 1)[0];
    this.lists.splice(e.toIndex, 0, list);

    const beforeIndex = (this.lists[e.toIndex - 1] == null) ? 0 : this.lists[e.toIndex - 1].indexList;
    const afterIndex = (this.lists[e.toIndex + 1] == null) ? 0 : this.lists[e.toIndex + 1].indexList;
    let indexList: number;
    if (beforeIndex === 0 && afterIndex === 0) {
      indexList = 1;
    } else if (beforeIndex === 0) {
      indexList = afterIndex / 2;
    } else if (afterIndex === 0) {
      indexList  = beforeIndex + 1;
    } else {
      indexList = (beforeIndex + afterIndex) / 2;
    }
    const listmodel = new ListModel<number>();
    listmodel.id = list.id;
    listmodel.value = indexList;
    this.service.UpdateListPosition(listmodel).subscribe();
  }

  onTaskDragStart(e) {
    e.itemData = e.fromData.tasks[e.fromIndex];
  }

  onTaskDrop(e) {
    e.fromData.tasks.splice(e.fromIndex, 1);
    e.toData.tasks.splice(e.toIndex, 0, e.itemData);
    // tslint:disable-next-line:no-unused-expression
    const listId = e.toData.id;
    // get index before and after
    const beforeIndex = (e.toData.tasks[e.toIndex - 1] == null) ? 0 : e.toData.tasks[e.toIndex - 1].indexTask;
    const afterIndex = (e.toData.tasks[e.toIndex + 1] == null) ? 0 : e.toData.tasks[e.toIndex + 1].indexTask;
    // change index
    let index: number;
    if (beforeIndex === 0 && afterIndex === 0) {
      index = 1;
    } else if (beforeIndex === 0) {
      index = afterIndex / 2;
    } else if (afterIndex === 0) {
      index  = beforeIndex + 1;
    } else {
      index = (beforeIndex + afterIndex) / 2;
    }
    // api update
    const obj = e.itemData;
    obj.listId = listId;
    obj.indexTask = index;
    this.service.UpdateTask(obj.id, obj).subscribe();
  }

  showFormCreate(e, list: List) {
    this.popupVisible = true;
    this.task = new Task();
    this.task.indexTask = list.tasks ? list.tasks[list.tasks.length - 1].indexTask + 1 : 1;
    this.task.listId = list.id;
  }

  showFormEdit(task: Task) {
    this.task = task;
    this.popupVisible = true;

    console.log(this.lists);
  }
}
