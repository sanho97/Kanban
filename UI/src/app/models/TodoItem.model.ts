export class TodoItem {
  id: number;
  name: string;
  isActive: boolean;
  checklistId: number;
}

export  class TodoItemModel<T> {
  id: number;
  value: T;
  checklistId: number;
}
