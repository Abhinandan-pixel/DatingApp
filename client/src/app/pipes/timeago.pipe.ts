import { Pipe, PipeTransform } from '@angular/core';
import { format } from 'timeago.js';

@Pipe({
  name: 'timeago',
  pure: true,
})
export class TimeAgoPipe implements PipeTransform {
  transform(value: Date | string | number): string {
    if (!value) return '';
    return format(value);
  }
}
