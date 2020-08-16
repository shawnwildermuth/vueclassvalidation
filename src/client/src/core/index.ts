export function clearObject(obj: Object) {
  Object.keys(obj).forEach((key) => { delete (obj as any)[key]; });
} 