import { IDropdownItem } from '../../../../lib/interfaces/IDropdownItem';

export interface ILogMessageFilterOptions {
  from: string;
  to: string;
  selectedItem: number;
  triggerItems: IDropdownItem[];
}
