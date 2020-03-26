import { TodoItem } from './TodoItem.model';

export class Checklist {
  id: number;
  name: string;
  taskId: number;
  todoItem: TodoItem[];
}
