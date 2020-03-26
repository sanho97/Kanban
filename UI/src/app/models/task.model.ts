import { Checklist } from './Checklist.model';

export class Task {
  id: number;
  name: string;
  ownerId: number;
  startDate: Date;
  dueDate: Date;
  priority: number;
  assignedEmployeeId: number;
  indexTask: number;
  listId: number;
  assignedEmployee: AssignedEmployee;
  owner: Owner;
  checklist: Checklist[];
}

export class AssignedEmployee {
  id: number;
  name: string;
}

export class Owner {
  id: number;
  name: string;
}

export class TaskModelToEdit<T> {
  id: number;
  value: T;
}

