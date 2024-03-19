import moment from 'moment';

export interface ILogMessage {
  id: number;
  trigger: string;
  message: string;
  exceptionMessage: string;
  stacktrace: string;
  timeStamp: string;
  onDelete: (id: number) => void | Promise<void>;
}
