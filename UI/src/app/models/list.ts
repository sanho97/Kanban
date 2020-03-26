import {Task} from './task.model';

export class List {
  id: number;
  name: string;
  indexList: number;
  tasks: Task[];
}

export class ListModel<T> {
  id: number;
  value: T;
}
