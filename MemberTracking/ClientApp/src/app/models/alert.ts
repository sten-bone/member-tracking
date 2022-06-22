
export class Alert {
  type: '' | 'success' | 'failure' = '';
  message: string = '';

  constructor(type: '' | 'success' | 'failure', message: string) {
    this.type = type;
    this.message = message;
  }

  static createDefault(): Alert {
    return new Alert('', '');
  }
}
